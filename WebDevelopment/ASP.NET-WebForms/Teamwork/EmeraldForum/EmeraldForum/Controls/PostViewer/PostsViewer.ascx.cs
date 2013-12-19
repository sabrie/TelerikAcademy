using System.Collections.Generic;
using EmeraldForum.Models;
using System;
using System.Linq;
using System.Web.UI;

namespace EmeraldForum.Controls.PostViewer
{
    public partial class PostView : System.Web.UI.UserControl
    {
        public ICollection<EmeraldForum.Models.Post> Posts { get; set; }

        public int PostId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RepeaterPosts.DataSource = this.Posts;
            this.RepeaterPosts.DataBind();

            this.IncludeCss();
        }

        private void IncludeCss()
        {
            ClientScriptManager cs = Page.ClientScript;
            string cssRelativeUrl = this.TemplateSourceDirectory + "/Styles/post-viewer-styles.css";

            if (!cs.IsClientScriptBlockRegistered(cssRelativeUrl))
            {
                string cssLinkCode = string.Format(
                    @"<link href='{0}' rel='stylesheet' type='text/css' />",
                    cssRelativeUrl);
                cs.RegisterClientScriptBlock(this.GetType(), cssRelativeUrl, cssLinkCode);
            }
        }

        protected void ButtonGoToPost_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            if (e.CommandName == "GoToPost")
            {
                this.Response.Redirect("Post.aspx?id=" + e.CommandArgument);
            }

        }

        protected void LinkButtonSingleTagPosts_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            if (e.CommandName == "GoToSingeTagPosts")
            {
                this.Response.Redirect("SingleTagPosts.aspx?id=" + e.CommandArgument);
            }
        }

        protected void GoToUserProfile_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            if (e.CommandName == "GoToCreatorProfile")
            {
                this.Response.Redirect("UserProfile.aspx?id=" + e.CommandArgument);
            }
        }
    }
}