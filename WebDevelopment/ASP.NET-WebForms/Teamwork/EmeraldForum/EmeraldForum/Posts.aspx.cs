using EmeraldForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmeraldForum
{
    public partial class AllPosts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<EmeraldForum.Models.Post> GridViewAllPosts_GetData()
        {
            var contect = new ForumEmeraldContext();
            var allPosts = contect.Posts;
            return allPosts.OrderBy(p => p.Id);
        }
    }
}