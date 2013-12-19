using EmeraldForum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace EmeraldForum.Account
{
    public partial class Register : Page
    {
        private const string MainPath = "~/Images/Users/";
        private const string PngImageFormat = "image/png";
        private const string JpegImageFormat = "image/jpeg";
        private const string DefaultImagePath = "~/Images/Users/default-user-profile-image.jpg";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.Response.Redirect("~/Default.aspx");
            }
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {

            string userName = UserName.Text;
            var manager = new AuthenticationIdentityManager(new IdentityStore(new ForumEmeraldContext()));
            string filename = string.Empty;

            ForumUser user = new ForumUser()
            {
                UserName = userName,
                Email = this.TextBoxEmail.Text,
            };

            var fileUpload = this.FileUploadPhoto;
            if (fileUpload.HasFile && (fileUpload.PostedFile.ContentType == PngImageFormat ||
                    FileUploadPhoto.PostedFile.ContentType == JpegImageFormat))
            {
                filename = userName + GetPhotoExtension(FileUploadPhoto.PostedFile.FileName);
                fileUpload.SaveAs(Server.MapPath(MainPath) + filename);
                user.PhotoPath = MainPath + filename;
            }
            else
            {
                user.PhotoPath = DefaultImagePath;
            }

            IdentityResult result = manager.Users.CreateLocalUser(user, Password.Text);

            if (result.Success)
            {
                manager.Authentication.SignIn(Context.GetOwinContext().Authentication, user.Id, isPersistent: false);
                this.AddUserToRole();
                OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                if (this.FileUploadPhoto.HasFile)
                {
                    File.Delete(this.Server.MapPath(MainPath + filename));
                }

                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        private string GetPhotoExtension(string fileName)
        {
            var dotIndex = fileName.LastIndexOf('.');
            var extension = fileName.Substring(dotIndex);

            return extension;
        }

        private void AddUserToRole()
        {
            var context = new ForumEmeraldContext();
            using (context)
            {
                var userRole = context.Roles.FirstOrDefault(x => x.Name == "User");
                var userRolePair = new UserRole();
                userRolePair.RoleId = userRole.Id;

                var username = this.UserName.Text;
                var user = context.Users.FirstOrDefault(x => x.UserName == username);
                userRolePair.UserId = user.Id;
                context.UserRoles.Add(userRolePair);
                context.SaveChanges();
            }
        }
    }
}