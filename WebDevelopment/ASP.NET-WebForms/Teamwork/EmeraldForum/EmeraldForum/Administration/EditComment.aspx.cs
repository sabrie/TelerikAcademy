using EmeraldForum.Models;
using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmeraldForum.Administration
{
    public partial class EditComment : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            int commentId = Convert.ToInt32(Request.QueryString["id"]);

            var context = new ForumEmeraldContext();
            var comment = context.Comments.Find(commentId);

            int postId = comment.Post.Id;

            this.LabelPostTitle.Text = context.Posts.Find(postId).Title;
            this.TextBoxEditableCommentContent.Text = comment.Text;
        }

        protected void ButtonEditComment_Click(object sender, EventArgs e)
        {
            this.Validate("EditComment");
            if (this.IsValid)
            {
                try
                {
                    int commentId = Convert.ToInt32(Request.QueryString["id"]);

                    var context = new ForumEmeraldContext();
                    var commentToEdit = context.Comments.Find(commentId);

                    commentToEdit.Text = this.TextBoxEditableCommentContent.Text;

                    context.SaveChanges();

                    var postId = commentToEdit.Post.Id;
                    Response.Redirect("~/Administration/EditPost.aspx?id=" + postId, false);
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }
    }
}