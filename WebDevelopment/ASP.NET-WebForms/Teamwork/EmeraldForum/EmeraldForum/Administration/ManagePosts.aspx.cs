using EmeraldForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmeraldForum.Administration
{
    public partial class ManagePosts : System.Web.UI.Page
    {
        public IQueryable<EmeraldForum.Models.Post> GridViewManageAllPosts_GetData()
        {
            var context = new ForumEmeraldContext();
            var allPosts = context.Posts;
            return allPosts.OrderBy(p => p.Id);
        }
    }
}