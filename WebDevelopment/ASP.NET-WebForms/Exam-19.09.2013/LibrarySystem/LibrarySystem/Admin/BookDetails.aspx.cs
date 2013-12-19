using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int bookId = Convert.ToInt32(Request.QueryString["id"]);

            if (bookId == 0)
            {
                Response.Redirect("~/Home.aspx");
            }
            LibrarySystemEntities context = new LibrarySystemEntities();

            // bind book
            var book = context.Books.Where(u => u.BookId == bookId).ToList();
            this.ListViewBookDetails.DataSource = book;
            this.ListViewBookDetails.DataBind();
        }
    }
}