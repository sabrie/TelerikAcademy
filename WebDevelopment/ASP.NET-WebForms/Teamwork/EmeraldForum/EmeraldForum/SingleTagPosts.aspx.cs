using EmeraldForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmeraldForum
{
    public partial class SingleTagPosts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int tagId = Convert.ToInt32(Request.QueryString["id"]);
            var context = new ForumEmeraldContext();

            var posts = (from p in context.Posts
                            from t in p.Tags
                      where t.Id == tagId
                      select p).ToList();

            this.ListViewSingleTagPosts.DataSource = posts;
            this.DataBind();
        }
    }
}