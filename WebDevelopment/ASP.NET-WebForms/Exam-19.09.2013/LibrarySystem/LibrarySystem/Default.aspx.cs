using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();

            var categories = context.Categories.ToList();
            this.RepeaterCategories.DataSource = categories;
            this.RepeaterCategories.DataBind();

            this.IncludeCss();
        }

        private void IncludeCss()
        {
            ClientScriptManager cs = Page.ClientScript;
            string cssRelativeUrl = "~/Styles/home-page-styles.css";

            if (!cs.IsClientScriptBlockRegistered(cssRelativeUrl))
            {
                string cssLinkCode = string.Format(
                    @"<link href='{0}' rel='stylesheet' type='text/css' />",
                    cssRelativeUrl);
                cs.RegisterClientScriptBlock(this.GetType(), cssRelativeUrl, cssLinkCode);
            }
        }

        protected void LinkButtonSingleBook_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "GoToSingeBook")
            {
                this.Response.Redirect("Admin/BookDetails.aspx?id=" + e.CommandArgument);
            }
        }
    }
}