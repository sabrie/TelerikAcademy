using EmeraldForum.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.EntityFramework;
using Error_Handler_Control;
using System.Drawing;

namespace EmeraldForum.Administration
{
    public partial class EditUser : System.Web.UI.Page
    {
        private const string CommandBanUser = "BanUser";
        private const string CommandUnbanUser = "UnbanUser";
        private const string BannedRole = "Banned";
        private const string MainPath = "~/Images/Users/";
        private const string PngImageFormat = "image/png";
        private const string JpegImageFormat = "image/jpeg";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }
            else
            {
                this.BindUserInfo();
            }
        }

        protected void LinkButtonBan_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == CommandBanUser)
            {
                var userId = this.Request.QueryString["id"];
                var context = new ForumEmeraldContext();

                using (context)
                {
                    var bannedRole = context.Roles.FirstOrDefault(x => x.Name == BannedRole);
                    var userRolePair = new UserRole();
                    userRolePair.RoleId = bannedRole.Id;

                    var user = context.Users.FirstOrDefault(x => x.Id == userId);
                    userRolePair.UserId = user.Id;
                    context.UserRoles.Add(userRolePair);
                    context.SaveChanges();

                    this.BindUserInfo();
                }
            }
        }

        protected void LinkButtonUnban_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == CommandUnbanUser)
            {
                var userId = this.Request.QueryString["id"];
                var context = new ForumEmeraldContext();

                using (context)
                {
                    var bannedRole = context.Roles.FirstOrDefault(x => x.Name == BannedRole);
                    var roleToRemove = context.UserRoles.FirstOrDefault(x => x.UserId == userId && x.RoleId == bannedRole.Id);

                    context.UserRoles.Remove(roleToRemove);
                    context.SaveChanges();

                    this.BindUserInfo();
                }
            }
        }

        protected void ButtonUploadPhoto_Click(object sender, EventArgs e)
        {
            var fileUpload = this.FileUploadPhoto;
            if (!fileUpload.HasFile)
            {
                return;
            }
            else
            {
                if (fileUpload.HasFile && (fileUpload.PostedFile.ContentType == PngImageFormat ||
                    fileUpload.PostedFile.ContentType == JpegImageFormat))
                {

                    var context = new ForumEmeraldContext();

                    using (context)
                    {
                        var userId = this.Request.QueryString["id"];

                        var user = context.Users.FirstOrDefault(x => x.Id == userId);
                        if (user != null)
                        {
                            string fileName = user.UserName + GetPhotoExtension(fileUpload.PostedFile.FileName);
                            fileUpload.SaveAs(Server.MapPath(MainPath) + fileName);
                            user.PhotoPath = MainPath + fileName;
                            context.SaveChanges();
                            this.BindUserInfo();
                            ErrorSuccessNotifier.AddInfoMessage("Profile picture updated.");
                        }
                    }
                }
            }
        }

        private string GetPhotoExtension(string fileName)
        {
            var dotIndex = fileName.LastIndexOf('.');
            var extension = fileName.Substring(dotIndex);

            return extension;
        }

        protected void ButtonChangeEmail_Click(object sender, EventArgs e)
        {
            this.Validate("ValidateEmail");
            if (this.IsValid)
            {
                var context = new ForumEmeraldContext();
                using (context)
                {
                    var userId = this.Request.QueryString["id"];
                    var user = context.Users.FirstOrDefault(x => x.Id == userId);
                    user.Email = this.TextBoxEmail.Text;
                    context.SaveChanges();
                    this.BindUserInfo();
                    this.TextBoxEmail.Text = string.Empty;
                    ErrorSuccessNotifier.AddInfoMessage("Email address updated.");
                }
            }
        }

        protected void ButtonChangeRole_Click(object sender, EventArgs e)
        {
            var userId = this.Request.QueryString["id"];
            var selectedRoleId = this.DropDownListRoles.SelectedItem.Value;

            var context = new ForumEmeraldContext();
            using (context)
            {
                var newUserRole = new UserRole();
                newUserRole.RoleId = selectedRoleId;
                newUserRole.UserId = userId;

                var oldUserRoles = context.UserRoles.Include("Role")
                    .Where(x => x.UserId == userId && x.Role.Name != BannedRole).ToList();

                context.UserRoles.RemoveRange(oldUserRoles);
                context.UserRoles.Add(newUserRole);
                context.SaveChanges();

                this.BindUserInfo();
            }
        }

        private void BindUserInfo()
        {
            var userId = this.Request.QueryString["id"];
            if (string.IsNullOrWhiteSpace(userId) || userId == string.Empty)
            {
                this.Response.Redirect("~/Administration/ManageUsers.aspx");
            }

            var context = new ForumEmeraldContext();
            using (context)
            {
                var user = context.Users.Include("Roles").FirstOrDefault(x => x.Id == userId);
                if (user != null)
                {
                    this.ImageUser.ImageUrl = user.PhotoPath;
                    this.ImageUser.AlternateText = user.UserName;
                    this.LabelUsername.Text = this.Server.HtmlEncode(user.UserName);
                    this.LabelCurrentEmail.Text = this.Server.HtmlEncode(user.Email);

                    var officialRole = user.Roles.FirstOrDefault(x => x.Role.Name != BannedRole);
                    this.LabelUserRole.Text = officialRole.Role.Name;

                    var allRoles = context.Roles.Where(x => x.Name != BannedRole).ToList();
                    this.DropDownListRoles.DataSource = allRoles;
                    this.DropDownListRoles.DataBind();

                    bool isBanned = user.Roles.Any(x => x.Role.Name == BannedRole);
                    if (isBanned)
                    {
                        this.LinkButtonUnban.CommandArgument = user.Id;
                        this.LinkButtonBan.Visible = false;
                        this.LinkButtonUnban.Visible = true;
                        this.LabelStatus.Text = "User is banned!";
                        this.LabelStatus.Visible = true;
                    }
                    else
                    {
                        this.LinkButtonBan.CommandArgument = user.Id;
                        this.LinkButtonUnban.Visible = false;
                        this.LinkButtonBan.Visible = true;
                        this.LabelStatus.Visible = false;
                    }
                }
            }
        }


    }
}