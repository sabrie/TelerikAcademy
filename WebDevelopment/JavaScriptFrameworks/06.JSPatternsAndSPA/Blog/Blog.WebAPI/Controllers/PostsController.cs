namespace Blog.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Blog.Data;
    using Blog.Models;
    using Blog.WebAPI.Models;
    using System.Collections;

    public class PostsController : BaseApiController
    {
        private static char[] delimiters = { '\r', '\n', ' ', '_', '.', ',', ';', ':', '!', '?', '(', ')' };

        // GET api/posts
        [ActionName("all")]
        public HttpResponseMessage GetAll(string sessionKey)
        {
            var responseMessage = this.PerformOperation(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var context = new BlogDbContext();
                var keyExists = context.Users
                    .Any(user => user.SessionKey == sessionKey);

                if (!keyExists)
                {
                    throw new ServerErrorException(
                        "Invalid or expired session",
                        HttpStatusCode.BadRequest);
                }

                return AllPosts(context);
            });

            return responseMessage;
        }

        // GET api/posts?tags=tag1,tag2
        public HttpResponseMessage GetByTags(string sessionKey, string tags)
        {
            var responseMessage = this.PerformOperation(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var context = new BlogDbContext();
                var keyExists = context.Users
                    .Any(user => user.SessionKey == sessionKey);

                if (!keyExists)
                {
                    throw new ServerErrorException(
                        "Invalid or expired session",
                        HttpStatusCode.BadRequest);
                }

                if (tags == null)
                {
                    throw new ServerErrorException(
                        "Tags value must be set",
                        HttpStatusCode.BadRequest);
                }

                var tagsCollection = tags.ToLower().Split(',');

                return AllPosts(context)
                    .Where(p => tagsCollection.All(tag => p.Tags.Contains(tag)));
            });

            return responseMessage;
        }

        // POST api/posts?sessionKey=...
        public HttpResponseMessage PostCreateBlogPost(string sessionKey, [FromBody] PostCreateNewModel model)
        {
            var responseMessage = this.PerformOperation(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var context = new BlogDbContext();
                var user = context.Users
                    .FirstOrDefault(u => u.SessionKey == sessionKey);

                if (user == null)
                {
                    throw new ServerErrorException(
                        "Invalid or expired session",
                        HttpStatusCode.BadRequest);
                }

                this.ValidatePostCreateModel(model);

                var tagEntities = GetAllPostTags(context, model.Title, model.Tags);

                var postEntity = new Post()
                {
                    Title = model.Title,
                    Text = model.Text,
                    PostDate = DateTime.Now,
                    User = user,
                    Tags = tagEntities
                };

                context.Posts.Add(postEntity);
                context.SaveChanges();

                var postModel = new PostCreatedModel()
                {
                    Id = postEntity.Id,
                    Title = postEntity.Title
                };

                return Request.CreateResponse(
                    HttpStatusCode.Created,
                    postModel);
            });

            return responseMessage;
        }

        // PUT api/posts/{postId}/comment
        [ActionName("comment")]
        public HttpResponseMessage PutBlogPostComment(string sessionKey, int postId, [FromBody] CommentCreateModel model)
        {
            var responseMessage = this.PerformOperation(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var context = new BlogDbContext();
                var user = context.Users
                    .FirstOrDefault(u => u.SessionKey == sessionKey);

                if (user == null)
                {
                    throw new ServerErrorException(
                        "Invalid or expired session",
                        HttpStatusCode.BadRequest);
                }

                var post = context.Posts
                    .FirstOrDefault(p => p.Id == postId);

                if (post == null)
                {
                    throw new ServerErrorException(
                        "Post does not exist",
                        HttpStatusCode.BadRequest);
                }

                this.ValidateCommentCreateModel(model);

                var commentEntity = new Comment()
                {
                    Text = model.Text,
                    PostDate = DateTime.Now,
                    Post = post,
                    User = user
                };

                context.Comments.Add(commentEntity);
                context.SaveChanges();

                return;
            });

            return responseMessage;
        }

        // GET api/posts/id
        public HttpResponseMessage GetSinglePostById(string sessionKey, int postId)
        {
            var responseMessage = this.PerformOperation(() =>
            {
                this.ValidateSessionKey(sessionKey);

                var context = new BlogDbContext();
                var user = context.Users
                    .FirstOrDefault(u => u.SessionKey == sessionKey);

                if (user == null)
                {
                    throw new ServerErrorException(
                        "Invalid or expired session",
                        HttpStatusCode.BadRequest);
                }

                var post = context.Posts
                    .FirstOrDefault(p => p.Id == postId);

                if (post == null)
                {
                    throw new ServerErrorException(
                        "Post does not exist",
                        HttpStatusCode.BadRequest);
                }
                                
                var postModel = new PostModel()
                {
                    Id = post.Id,
                    PostedBy = post.User.DisplayName,
                    PostDate = post.PostDate,
                    Title = post.Title,
                    Text = post.Text,
                    Tags = post.Tags.Select(tag => tag.Name),
                    Comments = post.Comments.Select(comment =>
                            new CommentModel()
                            {
                                Text = comment.Text,
                                CommentedBy = comment.User.DisplayName,
                                PostDate = comment.PostDate
                            }
                        )
                };

                return Request.CreateResponse(
                    HttpStatusCode.OK,
                    postModel);
            });

            return responseMessage;
        }

        private static IOrderedQueryable<PostModel> AllPosts(BlogDbContext context)
        {
            var postModels = context.Posts
                .Select(post =>
                    new PostModel()
                    {
                        Id = post.Id,
                        Title = post.Title,
                        PostedBy = post.User.DisplayName,
                        PostDate = post.PostDate,
                        Text = post.Text,
                        Tags = post.Tags.Select(tag => tag.Name),
                        Comments = post.Comments.Select(comment =>
                                new CommentModel()
                                {
                                    Text = comment.Text,
                                    CommentedBy = comment.User.DisplayName,
                                    PostDate = comment.PostDate
                                }
                            )
                    }
                );

            return postModels
                .OrderByDescending(pm => pm.PostDate);
        }

        private static ICollection<Tag> GetAllPostTags(BlogDbContext context, string postTitle, IEnumerable<string> postTags)
        {
            var titleWorlds = postTitle.Split(
                delimiters,
                StringSplitOptions.RemoveEmptyEntries);

            var tagEntities = new List<Tag>();

            // For each create post request title word
            foreach (var word in titleWorlds)
            {
                if (string.IsNullOrWhiteSpace(word))
                {
                    continue;
                }

                var tagEntity = GetOrCreateTag(context, word);
                tagEntities.Add(tagEntity);
            }

            // Foreach post create post request tags
            if (postTags != null)
            {
                foreach (var tagWord in postTags)
                {
                    if (string.IsNullOrWhiteSpace(tagWord))
                    {
                        continue;
                    }

                    // Add if not already added
                    var newTagEntity = GetOrCreateTag(context, tagWord);
                    if (tagEntities.Contains(newTagEntity) == false)
                    {
                        tagEntities.Add(newTagEntity);
                    }
                }
            }

            return tagEntities;
        }

        private static Tag GetOrCreateTag(BlogDbContext context, string name)
        {
            var nameToLower = name.ToLower();
            var tagEntity = context.Tags
                .FirstOrDefault(tag => tag.Name == nameToLower);

            // If entity already exists
            if (tagEntity != null)
            {
                return tagEntity;
            }

            var newTagEntity = new Tag()
            {
                Name = nameToLower
            };

            context.Tags.Add(newTagEntity);
            context.SaveChanges();

            return newTagEntity;
        }

        private void ValidatePostCreateModel(PostCreateNewModel model)
        {
            if (model == null)
            {
                throw new ServerErrorException(
                    "Post cannot be null",
                    HttpStatusCode.BadRequest);
            }

            if (string.IsNullOrEmpty(model.Title))
            {
                throw new ServerErrorException(
                    "Post title must be set",
                    HttpStatusCode.BadRequest);
            }

            if (string.IsNullOrEmpty(model.Text))
            {
                throw new ServerErrorException(
                    "Post text must be set",
                    HttpStatusCode.BadRequest);
            }
        }

        private void ValidateCommentCreateModel(CommentCreateModel model)
        {
            if (model == null)
            {
                throw new ServerErrorException(
                    "Comment cannot be null",
                    HttpStatusCode.BadRequest);
            }

            if (string.IsNullOrEmpty(model.Text))
            {
                throw new ServerErrorException(
                    "Comment text must be set",
                    HttpStatusCode.BadRequest);
            }
        }
    }
}
