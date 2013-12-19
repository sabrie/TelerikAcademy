using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmeraldForum.Models;

namespace EmeraldForum
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.GridViewResults.DataSource = null;
            //this.GridViewResults.DataBind();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<EmeraldForum.Models.Post> GridViewResults_GetData(
            [System.Web.ModelBinding.Control("TextBoxSearchText")] 
            string searchText)
        {
            if (String.IsNullOrEmpty(searchText))
            {
                return null;
            }

            char[] separators = new char[] { ' ', ',', ';' };
            string[] keywords = searchText.Split(separators,
                StringSplitOptions.RemoveEmptyEntries);
            var context = new ForumEmeraldContext();

            IQueryable<EmeraldForum.Models.Post> resultPosts = context.Posts.
                Where(p => keywords.
                    Any(w => p.Title.Contains(w)));

            return resultPosts.OrderBy(p => p.Id);
        }
    }
}