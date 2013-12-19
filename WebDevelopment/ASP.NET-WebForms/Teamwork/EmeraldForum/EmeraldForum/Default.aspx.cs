using EmeraldForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmeraldForum
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User.IsInRole("Banned"))
            {
                this.LabelBannedUser.Visible = true;
            }
            var context = new ForumEmeraldContext();
            using (context)
            {
                var latestPosts = context.Posts.Include("User").Include("Tags")
                    .OrderByDescending(x => x.PostDate).Take(10).ToList();

                this.PostsViewer.Posts = latestPosts;
                this.PostsViewer.DataBind();
            }
        }
    }
}