using EmeraldForum.Models;
using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmeraldForum
{
    public partial class Post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                this.AddCommentContainer.Visible = false;
            }

            if (this.User.IsInRole("Banned"))
            {
                this.AddCommentContainer.Visible = false;
            }
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            int postId = int.Parse(Request.QueryString["id"]);

            // gather data
            var context = new ForumEmeraldContext();
            var currentPost = context.Posts.Find(postId);
            var postComments = context.Comments.Where(c => c.Post.Id == currentPost.Id).OrderByDescending(c => c.Date).ToList();

            // render post
            this.headerPostTitle.InnerText = currentPost.Title;
            this.divPostDate.InnerText = currentPost.PostDate.ToString();
            this.imgCreatorPhoto.ImageUrl = currentPost.User.PhotoPath;
            this.divPostCreatorName.InnerText = currentPost.User.UserName;
            this.divPostContent.InnerText = currentPost.Content;

            // render comments
            this.ListViewComments.DataSource = postComments;
            this.ListViewComments.DataBind();

            // render tags
            this.ListViewTags.DataSource = currentPost.Tags.ToList();
            this.ListViewTags.DataBind();
        }

        protected void ButtonComment_Click(object sender, EventArgs e)
        {
            this.Validate("AddComment");
            if (this.IsValid)
            {
                try
                {
                    var context = new ForumEmeraldContext();

                    // get needed data
                    int postId = int.Parse(Request.QueryString["id"]);
                    string commentText = this.TextBoxComment.Text;
                    var currentPost = context.Posts.Find(postId);
                    var currentUser = context.Users.Where(u => u.UserName == this.User.Identity.Name).FirstOrDefault();

                    // make new comment
                    Comment newComment = new Comment();
                    newComment.Text = commentText;
                    newComment.Post = currentPost;
                    newComment.Date = DateTime.Now;
                    newComment.User = currentUser;

                    context.Comments.Add(newComment);
                    context.SaveChanges();

                    this.TextBoxComment.Text = "";
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }
    }
}