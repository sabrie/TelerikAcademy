using EmeraldForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmeraldForum
{
    public partial class UserPosts : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            string userId = Request.QueryString["Id"];

            if (userId == string.Empty || string.IsNullOrWhiteSpace(userId))
            {
                Response.Redirect("~/Users.aspx");
            }
            var context = new ForumEmeraldContext();

            // bind user info
            var user = context.Users.Where(u => u.Id == userId).ToList();
            this.ListViewUser.DataSource = user;
            this.ListViewUser.DataBind();

            if (this.User.Identity.IsAuthenticated)
            {
                // bind user posts
                var posts = context.Posts.Where(p => p.User.Id == userId).ToList();
                this.ListViewUserPosts.DataSource = posts;
                this.ListViewUserPosts.DataBind();
            }
            else
            {
                this.ListViewUserPosts.Visible = false;
            }

        }
    }
}