using EmeraldForum.Models;
using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmeraldForum.Administration
{
    public partial class EditPost : System.Web.UI.Page
    {
        private int postId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.postId =
                Convert.ToInt32(Request.Params["id"]);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.postId = Convert.ToInt32(Request.QueryString["id"]);

            // gather data
            var context = new ForumEmeraldContext();
            var currentPost = context.Posts.Find(postId);
            var postComments = context.Comments.
                Where(c => c.Post.Id == currentPost.Id).
                OrderByDescending(c => c.Date).ToList();

            // render post
            this.PostDate.InnerText = currentPost.PostDate.ToString();
            this.imgCreatorPhoto.ImageUrl = currentPost.User.PhotoPath;
            this.PostCreatorName.InnerText = currentPost.User.UserName;

            this.TextBoxTitle.Text = currentPost.Title;
            this.TextBoxTitle.DataBind();
            this.TextBoxPostContent.Text = currentPost.Content;

            this.HyperLinkEditUser.NavigateUrl = "EditUser.aspx?id=" + currentPost.User.Id;

            // render comments
            this.ListViewComments.DataSource = postComments;
            this.ListViewComments.DataBind();

            // render tags
            this.ListViewTags.DataSource = currentPost.Tags.ToList();
            this.ListViewTags.DataBind();
            this.HyperLinkEditTags.NavigateUrl = "EditPostTags.aspx?id=" + currentPost.Id;
        }

        protected void ButtonSavePost_Click(object sender, EventArgs e)
        {
            using (var context = new ForumEmeraldContext())
            {
                var post = context.Posts.Find(this.postId);
                post.Title = this.TextBoxTitle.Text;
                post.Content = this.TextBoxPostContent.Text;
                try
                {
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddInfoMessage("Post edited successfuly!");
                    ErrorSuccessNotifier.ShowAfterRedirect = false;
                    //var adminMaster = this.Master;
                    //var notifier = (ErrorSuccessNotifier) adminMaster.Master.FindControl("ErrorSuccessNotifier");
                    //var panel = (UpdatePanel) adminMaster.Master.FindControl("UpdatePanelErrorSuccessNotifier");
                    //notifier.Update();
                    //panel.Update();
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }
    }
}