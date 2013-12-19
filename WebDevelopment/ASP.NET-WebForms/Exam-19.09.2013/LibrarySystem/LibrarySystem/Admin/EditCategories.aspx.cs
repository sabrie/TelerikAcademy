using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Error_Handler_Control;

namespace LibrarySystem
{
    public partial class Categories : System.Web.UI.Page
    {
        private const string CommandEditCategory = "EditCategory";
        private const string CommandDeleteCategory = "DeleteCategory";
        private const int MaxCategoryNameLength = 100;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();

            var categories = context.Categories.ToList();
            this.GridViewAllCategories.DataSource = categories;
            this.GridViewAllCategories.DataBind();
        }

        protected void GridViewAllCategories_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewAllCategories.PageIndex = e.NewPageIndex;
            this.GridViewAllCategories.DataBind();
        }

        protected void LinkButtonShowCreatePanel_Click(object sender, EventArgs e)
        {
            this.PanelCreateCategory.Visible = true;
            this.PanelEditCategory.Visible = false;
            this.LinkButtonShowCreatePanel.Visible = false;
        }

        protected void LinkButtonCreateCategory_Click(object sender, EventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();

            Category newCategory = new Category() 
            { 
                Name = this.TextBoxCategoryName.Text
            };

            if (newCategory.Name.Length > MaxCategoryNameLength)
            {
                ErrorSuccessNotifier.AddErrorMessage("The category name is too long, it has to be up to " + MaxCategoryNameLength + " characters.");
                return;
            }

            if (newCategory.Name == string.Empty)
            {
                ErrorSuccessNotifier.AddErrorMessage("The category name is mandatory.");
                return;
            }

            context.Categories.Add(newCategory);
            context.SaveChanges();

            this.PanelCreateCategory.Visible = false;
            this.TextBoxCategoryName.Text = string.Empty;
            this.LinkButtonShowCreatePanel.Visible = true;
        }

        protected void LinkButtonCancelCreating_Click(object sender, EventArgs e)
        {
            this.TextBoxCategoryName.Text = string.Empty;
            this.PanelCreateCategory.Visible = false;
            this.PanelEditCategory.Visible = false;
            this.LinkButtonShowCreatePanel.Visible = true;
        }

        protected void LinkButtonDeleteCategory_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == CommandDeleteCategory)
            {
                int categoryId = Convert.ToInt32(e.CommandArgument.ToString());

                LibrarySystemEntities context = new LibrarySystemEntities();

                Category categoryToRemove = context.Categories.Find(categoryId);

                context.Books.RemoveRange(categoryToRemove.Books);
                context.Categories.Remove(categoryToRemove);

                context.SaveChanges();
            }
        }

        protected void LinkButtonShowEditPanel_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == CommandEditCategory)
            {
                int categoryId = Convert.ToInt32(e.CommandArgument.ToString());
                this.HiddenField.Text = categoryId.ToString();

                LibrarySystemEntities context = new LibrarySystemEntities();

                Category category = context.Categories.Find(categoryId);
                this.TextBoxEditedCategoryName.Text = category.Name;                
            }

            this.LinkButtonShowCreatePanel.Visible = false;
            this.PanelCreateCategory.Visible = false;
            this.PanelEditCategory.Visible = true;
        }

        protected void LinkButtonEditCategory_Click(object sender, EventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();

            int categoryId = Convert.ToInt32(this.HiddenField.Text);
            Category category = context.Categories.Find(categoryId);
            category.Name = this.TextBoxEditedCategoryName.Text;

            if (category.Name == string.Empty)
            {
                ErrorSuccessNotifier.AddErrorMessage("The category name is mandatory.");
                return;
            }

            if (category.Name.Length >= MaxCategoryNameLength)
            {
                ErrorSuccessNotifier.AddErrorMessage("The category name is too long, it has to be up to " + MaxCategoryNameLength + " characters.");
                return;
            }

            context.SaveChanges();

            this.PanelEditCategory.Visible = false;
            this.LinkButtonShowCreatePanel.Visible = true;
        }

        protected void LinkButtonCancelEditing_Click(object sender, EventArgs e)
        {
            this.LinkButtonShowCreatePanel.Visible = true;
            this.PanelCreateCategory.Visible = false;
            this.PanelEditCategory.Visible = false;
        }     
    }
}