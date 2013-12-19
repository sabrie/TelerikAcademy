using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmeraldForum.Models;

namespace EmeraldForum
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new ForumEmeraldContext();

            this.ListViewUsers.DataSource = context.Users.ToList();
            this.ListViewUsers.DataBind();
        }

        protected void LinkButtonUsername_Command(object sender, CommandEventArgs e)
        {

        }
    }
}