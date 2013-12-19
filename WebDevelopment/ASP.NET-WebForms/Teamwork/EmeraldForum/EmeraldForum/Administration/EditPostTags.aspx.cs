using EmeraldForum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmeraldForum.Administration
{
    public partial class EditPostTags : System.Web.UI.Page
    {
        protected string postTitle;
        protected int postId;
        protected void Page_Prerender(object sender, EventArgs e)
        {
            int postId = int.Parse(Request.QueryString["id"]);

            var context = new ForumEmeraldContext();
            var currentPost = context.Posts.Find(postId);
            this.postTitle = currentPost.Title;
            this.postId = currentPost.Id;

            this.GridViewTags.DataSource = currentPost.Tags.ToList();
            this.DataBind();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            int postId = int.Parse(Request.QueryString["id"]);

            var context = new ForumEmeraldContext();
            var currentPost = context.Posts.Find(postId);


        }

        protected void GridViewTags_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int tagId = int.Parse(this.GridViewTags.DataKeys[e.RowIndex].Value.ToString());

            int postId = int.Parse(Request.QueryString["id"]);
            var context = new ForumEmeraldContext();
            var currentPost = context.Posts.Find(postId);

            var deletedTag = context.Tags.Find(tagId);

            currentPost.Tags.Remove(deletedTag);
            context.SaveChanges();
        }

        protected void ButtonAddTags_Click(object sender, EventArgs e)
        {
            string[] tags = this.TextBoxPostTags.Text.Split(' ');
            int postId = int.Parse(Request.QueryString["id"]);
            var context = new ForumEmeraldContext();
            var currentPost = context.Posts.Find(postId);

            foreach (var tagName in tags)
            {
                Tag newTag = CreateOrLoadTag(context, tagName);
                currentPost.Tags.Add(newTag);
            }

            context.SaveChanges();
            this.TextBoxPostTags.Text = "";
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