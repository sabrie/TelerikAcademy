using EmeraldForum.Models;
using Error_Handler_Control;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmeraldForum.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        private const string MainPath = "~/Images/Users/";
        private const string PngImageFormat = "image/png";
        private const string JpegImageFormat = "image/jpeg";

        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                // Determine the sections to render
                ILoginManager manager = new IdentityManager(new IdentityStore(new ForumEmeraldContext())).Logins;
                if (manager.HasLocalLogin(User.Identity.GetUserId()))
                {
                    changePasswordHolder.Visible = true;
                }
                else
                {
                    setPassword.Visible = true;
                    changePasswordHolder.Visible = false;
                }
                CanRemoveExternalLogins = manager.GetLogins(User.Identity.GetUserId()).Count() > 1;

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }

                var context = new ForumEmeraldContext();
                using (context)
                {
                    var username = this.User.Identity.GetUserName();
                    var user = context.Users.FirstOrDefault(x => x.UserName == username);
                    this.ImageProfilePicture.ImageUrl = user.PhotoPath;
                    this.ImageProfilePicture.AlternateText = user.UserName;
                    this.LabelCurrentEmail.Text = this.Server.HtmlEncode(user.Email);
                    this.CurrentUser.InnerText = this.Server.HtmlEncode(user.UserName);
                }
            }
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                IPasswordManager manager = new IdentityManager(new IdentityStore(new ForumEmeraldContext())).Passwords;
                IdentityResult result = manager.ChangePassword(User.Identity.GetUserName(), CurrentPassword.Text, NewPassword.Text);
                if (result.Success)
                {
                    Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                }
                else
                {
                    AddErrors(result);
                }
            }
        }

        protected void SetPassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Create the local login info and link the local account to the user
                ILoginManager manager = new IdentityManager(new IdentityStore(new ForumEmeraldContext())).Logins;
                IdentityResult result = manager.AddLocalLogin(User.Identity.GetUserId(), User.Identity.GetUserName(), password.Text);
                if (result.Success)
                {
                    Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
                }
                else
                {
                    AddErrors(result);
                }
            }
        }

        public IEnumerable<IUserLogin> GetLogins()
        {
            ILoginManager manager = new IdentityManager(new IdentityStore(new ForumEmeraldContext())).Logins;
            var accounts = manager.GetLogins(User.Identity.GetUserId());
            CanRemoveExternalLogins = accounts.Count() > 1;
            return accounts;
        }

        public void RemoveLogin(string loginProvider, string providerKey)
        {
            ILoginManager manager = new IdentityManager(new IdentityStore(new ForumEmeraldContext())).Logins;
            var result = manager.RemoveLogin(User.Identity.GetUserId(), loginProvider, providerKey);
            var msg = result.Success
                ? "?m=RemoveLoginSuccess"
                : String.Empty;
            Response.Redirect("~/Account/Manage" + msg);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
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
                    var username = this.User.Identity.GetUserName();
                    string fileName = username + GetPhotoExtension(fileUpload.PostedFile.FileName);
                    fileUpload.SaveAs(Server.MapPath(MainPath) + fileName);

                    var context = new ForumEmeraldContext();
                    using (context)
                    {
                        var user = context.Users.FirstOrDefault(x => x.UserName == username);
                        user.PhotoPath = MainPath + fileName;
                        context.SaveChanges();
                        this.ImageProfilePicture.ImageUrl = user.PhotoPath;
                        ErrorSuccessNotifier.AddInfoMessage("Profile picture updated.");
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
                    string username = this.User.Identity.GetUserName();
                    var user = context.Users.FirstOrDefault(x => x.UserName == username);
                    user.Email = this.TextBoxEmail.Text;
                    context.SaveChanges();
                    this.LabelCurrentEmail.Text = user.Email;
                    this.TextBoxEmail.Text = string.Empty;
                    ErrorSuccessNotifier.AddInfoMessage("Email address updated.");

                }
            }
        }
    }
}