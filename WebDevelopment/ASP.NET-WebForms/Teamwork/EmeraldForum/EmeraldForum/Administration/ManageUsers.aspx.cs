using EmeraldForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmeraldForum.Administration
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        private const string CommandEditUser = "EditUser";
        private const string BannedRole = "Banned";
        private const string AdministratorRole = "Administrator";
        private const string UserRole = "User";

        private readonly string ctegoryAllUsers = "All users";
        private readonly string ctegoryBanned = "Banned users";
        private readonly string ctegoryUsers = "Users";
        private readonly string ctegoryAdmins = "Administrators";

        private bool searchOn = false;
        private string searchedCategory = string.Empty;
        private string searchCriteria = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ListViewAllUsers.DataBind();
            }
        }

        protected void LinkButtonEdit_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == CommandEditUser)
            {
                string userId = e.CommandArgument.ToString();
                this.Response.Redirect("~/Administration/EditUser.aspx?id=" + userId);
            }
        }

        public IQueryable<EmeraldForum.Models.ForumUser> ListViewAllUsers_GetData()
        {
            var context = new ForumEmeraldContext();

            IQueryable<ForumUser> allUsers = context.Users;
            this.searchedCategory = this.ctegoryAllUsers;
            this.searchCriteria = this.TextBoxSearchCriteria.Text;

            if (this.RadioButtonOnlyBanned.Checked)
            {
                allUsers = allUsers.Where(x => x.Roles.Any(r => r.Role.Name == BannedRole)).AsQueryable();
                this.searchedCategory = this.ctegoryBanned;
            }
            else if (this.RadioButtonOnlyAdministrators.Checked)
            {
                allUsers = allUsers.Where(x => x.Roles.Any(r => r.Role.Name == AdministratorRole)).AsQueryable();
                this.searchedCategory = this.ctegoryAdmins;
            }
            else if (this.RadioButtonOnlyUsers.Checked)
            {
                allUsers = allUsers.Where(x => x.Roles.Any(r => r.Role.Name == UserRole)).AsQueryable();
                this.searchedCategory = this.ctegoryUsers;
            }

            if (searchOn)
            {
                var searchText = this.TextBoxSearchCriteria.Text;
                char[] separators = new char[] { ' ', ',', ';' };
                string[] keywords = searchText.Split(separators,
                    StringSplitOptions.RemoveEmptyEntries);
                allUsers = allUsers.Where(x => keywords.Any(w => x.UserName.Contains(w)));
            }

            this.LabelSearchedBy.Visible = false;
            return allUsers.OrderBy(x => x.UserName);
        }

        protected void ListViewAllUsers_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label statusLabel;
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                statusLabel = (Label)e.Item.FindControl("LabelStatus");

                var user = e.Item.DataItem as ForumUser;
                string status = string.Empty;

                if (user.Roles.Any(x => x.Role.Name == BannedRole))
                {
                    status = "<span class='banned-status'>BANNED</span>, ";
                }

                var officialRole = user.Roles.FirstOrDefault(x => x.Role.Name != BannedRole);
                if (officialRole != null)
                {
                    status += officialRole.Role.Name;
                }

                statusLabel.Text = status;
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.Validate("SearchCriteria");
            if (this.IsValid)
            {
                this.searchOn = true;
                this.ListViewAllUsers.DataBind();

                this.LabelSearchedBy.Visible = true;
                var searchedBy = string.Format("Searched for <strong>{0}</strong> in <strong>{1}</strong>",
                   this.Server.HtmlEncode(this.searchCriteria), this.searchedCategory);
                this.LabelSearchedBy.Text = searchedBy;

                this.TextBoxSearchCriteria.Text = string.Empty;
            }
        }

        protected void CheckedChanged(object sender, EventArgs e)
        {
            this.ListViewAllUsers.DataBind();
        }
    }
}