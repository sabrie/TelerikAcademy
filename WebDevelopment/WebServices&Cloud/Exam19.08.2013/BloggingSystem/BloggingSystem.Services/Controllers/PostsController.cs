using BloggingSystem.DataLayer;
using BloggingSystem.Model;
using BloggingSystem.Services.Attributes;
using BloggingSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.ValueProviders;

namespace BloggingSystem.Services.Controllers
{
    public class PostsController : BaseApiController
    {
        // GET api/posts?sessionKey=...
        [HttpGet]
        public IQueryable<PostModel> GetAll(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystemContext();

                var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password");
                }

                var postEntities = context.Posts;
                
                IQueryable<PostModel> models = GetPostModelsFromDb(postEntities);
                
                return models.OrderByDescending(thr => thr.PostDate);
            });

            return responseMsg;
        }

        //api/posts?page=5&count=3&sessionKey=...
        public IQueryable<PostModel> GetPage(int page, int count, string sessionKey)
        {
            var models = this.GetAll(sessionKey)
                .Skip(page * count)
                .Take(count);
            return models;
        }

        // POST api/posts?sessionKey=....
        [HttpPost]
        public HttpResponseMessage PostCreatePost(string sessionKey, RequestPostModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new BloggingSystemContext();
                    using (context)
                    {
                        var postCreatedBy = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

                        var post = new Post()
                        {
                            Title = model.Title,
                            Text = model.Text,
                            PostDate = DateTime.Now,
                            User = postCreatedBy,
                            //Tags = 
                        };

                        context.Posts.Add(post);
                        context.SaveChanges();

                        //

                        //IEnumerable<string> modelTagsParts = model.Tags.ToString().Split(new char[] { ' ', ',', '!', '?' });

                        //List<TagModel> tagModels = new List<TagModel>();

                        //foreach (var tagName in modelTagsParts)
                        //{
                        //    var tagInDb = context.Tags.FirstOrDefault(t => t.Name == tagName);

                        //    if (tagInDb == null)
                        //    {
                        //        var newTagModel = new TagModel()
                        //        {
                        //            Name = tagName
                        //        };

                        //        tagModels.Add(newTagModel);
                        //    }
                        //    else
                        //    {
                        //        tagInDb.Post.Id = post.Id;
                        //        context.SaveChanges();
                        //    }
                        //}

                        //

                        var createdPost = new CreatedPostModel()
                        {
                            Id = post.Id,
                            Title = post.Title
                        };                        

                        var response =
                            this.Request.CreateResponse(HttpStatusCode.Created,
                                            createdPost);
                        return response;
                    }
                });

            return responseMsg;
        }

        // Search posts by a keyword
        // GET api/posts?keyword=...&sessionKey=...
        public IQueryable<PostModel> GetPostByKeyword(string keyword, string sessionKey)
        {
            var models = this.GetAll(sessionKey)
                .Where(p => p.Title.Contains(keyword));
            return models;
        }

        // Leave a comment
        // PUT api/posts/{postId}/comment
        [HttpPut]
        [ActionName("comment")]
        public HttpResponseMessage PutComment(string sessionKey, LeaveCommentModel commentModel, int postId)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new BloggingSystemContext();
                    using (context)
                    {
                        var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                        var post = context.Posts.FirstOrDefault(p => p.Id == postId);

                        var comment = new Comment()
                        {
                            Text = commentModel.Text,
                            User = user,
                            Post = post,
                            PostDate = DateTime.Now
                        };

                        context.Comments.Add(comment);
                        context.SaveChanges();

                        var response =
                            this.Request.CreateResponse(HttpStatusCode.OK);
                        
                        return response;
                    }
                });

            return responseMsg;
        }        

        private static IQueryable<PostModel> GetPostModelsFromDb(DbSet<Post> postEntities)
        {
            var models =
                (from postEntity in postEntities
                 select new PostModel()
                 {
                     Id = postEntity.Id,
                     Title = postEntity.Title,
                     PostedBy = postEntity.User.DisplayName,
                     PostDate = postEntity.PostDate,
                     Text = postEntity.Text,
                     Tags = (from tagEntity in postEntity.Tags
                             select tagEntity.Name),
                     Comments = (from commentEntity in postEntity.Comments
                                 select new CommentModel()
                                 {
                                     Text = commentEntity.Text,
                                     CommentedBy = commentEntity.User.DisplayName,
                                     PostDate = commentEntity.PostDate
                                 })
                 });
            return models;
        }
    }
}
