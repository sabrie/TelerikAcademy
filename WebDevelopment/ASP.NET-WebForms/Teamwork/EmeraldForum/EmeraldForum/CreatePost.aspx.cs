using EmeraldForum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Error_Handler_Control;

namespace EmeraldForum
{
    public partial class CreatePost : System.Web.UI.Page
    {
        private const int MaxTagsCount = 8;
        private const int MinTagsCount = 3;

        private const int MaxTagLength = 20;

        private const int MaxTitleLength = 100;
        private const int MinTitleLength = 4;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User.IsInRole("Banned"))
            {
                Response.Redirect("~/BannedUserPage.aspx");
            }
        }

        protected void ButtonCreatePost_Click(object sender, EventArgs e)
        {
            var context = new ForumEmeraldContext();

            string title = this.TextBoxPostTitle.Text;
            string content = this.TextBoxPostContent.Text;
            string[] tags = this.TextBoxPostTags.Text.Split(' ');
            var currentUser = context.Users.Where(u => u.UserName == this.User.Identity.Name).FirstOrDefault();

            // validate input
            if (title.Trim().Length > MaxTitleLength)
            {
                ErrorSuccessNotifier.AddErrorMessage("The tite is too long, it has to be up to " + MaxTitleLength + " characters.");
                return;
            }

            if (title.Trim().Length < MinTitleLength)
            {
                ErrorSuccessNotifier.AddErrorMessage("The title is too short, it has to be at least " + MinTitleLength + " characters."); 
            }

            if (tags.Length > MaxTagsCount)
            {
                ErrorSuccessNotifier.AddErrorMessage("Maximal allowed tags count is " + MaxTagsCount + ".");
                return;
            }

            if (tags.Length < MinTagsCount)
            {
                ErrorSuccessNotifier.AddErrorMessage("You need to add at least " + MinTagsCount + ".");
                return;
            }

            // validate tags
            foreach (var tagName in tags)
            {
                if (tagName.Length > MaxTagLength)
                {
                    ErrorSuccessNotifier.AddErrorMessage("Tags must be less than " + MaxTagLength + " characters.");
                    return;
                }
            }

            // validate content
            if (content.Trim() == "")
            {
                ErrorSuccessNotifier.AddErrorMessage("You must add content");
                return;
            }

            Models.Post post = new Models.Post();
            post.Title = title;
            post.Content = content;
            post.PostDate = DateTime.Now;
            post.User = currentUser;

            foreach (var tagName in tags)
            {
                Tag newTag = CreateOrLoadTag(context, tagName);
                post.Tags.Add(newTag);
            }

            context.Posts.Add(post);
            context.SaveChanges();

            Response.Redirect("~/Post.aspx?id=" + post.Id);
        }

        private static Tag CreateOrLoadTag(ForumEmeraldContext context, string tagName)
        {
            Tag existingTag =
                (from t in context.Tags
                 where t.Name.ToLower() == tagName.ToLower()
                 select t).FirstOrDefault();

            if (existingTag != null)
            {
                return existingTag;
            }
            else
            {
                try
                {
                    Tag newTag = new Tag();
                    newTag.Name = tagName;
                    context.Tags.Add(newTag);
                    context.SaveChanges();

                    return newTag;
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }

                return null;
            }
        }
    }
}