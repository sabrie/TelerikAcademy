using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Error_Handler_Control;

namespace LibrarySystem
{
    public partial class EditBooks : System.Web.UI.Page
    {
        private const string CommandEditBook = "EditBook";
        private const string CommandDeleteBook = "DeleteBook";
        private const int MaxTitleLength = 300;
        private const int MaxAuthorLength = 300;
        private const int MaxWebSiteLength = 120;
        private const int MaxISBNLength = 50;
        

        protected void Page_PreRender(object sender, EventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();

            // bind books
            var books = context.Books.ToList();
            this.GridViewAllBooks.DataSource = books;
            this.GridViewAllBooks.DataBind();

            // bind categories
            var categories = context.Categories.ToList();
            this.DropDownListCategories.DataSource = categories;
            this.DropDownListCategories.DataBind();

            this.DropDownListEditedCategories.DataSource = categories;
            this.DropDownListEditedCategories.DataBind();
        }

        protected void GridViewAllBooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewAllBooks.PageIndex = e.NewPageIndex;
            this.GridViewAllBooks.DataBind();
        }

        
        protected void LinkButtonDeleteBook_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == CommandDeleteBook)
            {
                int bookId = Convert.ToInt32(e.CommandArgument.ToString());

                LibrarySystemEntities context = new LibrarySystemEntities();

                Book bookToRemove = context.Books.Find(bookId);

                context.Books.Remove(bookToRemove);
                context.SaveChanges();
            }
        }

        protected void LinkButtonShowCreatePanel_Click(object sender, EventArgs e)
        {
            this.PanelCreateBook.Visible = true;
            this.PanelEditBook.Visible = false;
            this.LinkButtonShowCreatePanel.Visible = false;
        }

        protected void LinkButtonCreateBook_Click(object sender, EventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();

            var selectedCategoryName = this.DropDownListCategories.SelectedValue;
            var selectedCategoryId = context.Categories.Where(c => c.Name == selectedCategoryName).FirstOrDefault().CategoryId;
            
            Book newBook = new Book()
            { 
                Title = this.TextBoxTitle.Text,
                Author = this.TextBoxAuthor.Text,
                ISBN = this.TextBoxISBN.Text,
                WebSite = this.TextBoxWebSite.Text,
                Description = this.TextBoxDescription.Text,
                CategoryId = selectedCategoryId
            };

            if (newBook.Title.Length >= MaxTitleLength)
            {
                ErrorSuccessNotifier.AddErrorMessage("The book title is too long, it has to be up to " + MaxTitleLength + " characters.");
                return;
            }

            if (newBook.Author.Length >= MaxAuthorLength)
            {
                ErrorSuccessNotifier.AddErrorMessage("The book author(s) is too long, it has to be up to " + MaxAuthorLength + " characters.");
                return;
            }

            if (newBook.ISBN.Length >= MaxISBNLength)
            {
                ErrorSuccessNotifier.AddErrorMessage("The book website is too long, it has to be up to " + MaxISBNLength + " characters.");
                return;
            }

            if (newBook.WebSite.Length >= MaxWebSiteLength)
            {
                ErrorSuccessNotifier.AddErrorMessage("The book website is too long, it has to be up to " + MaxWebSiteLength + " characters.");
                return;
            }

            if (newBook.Title == string.Empty)
            {
                ErrorSuccessNotifier.AddErrorMessage("The book title is mandatory.");
                return;
            }

            if (newBook.Author == string.Empty)
            {
                ErrorSuccessNotifier.AddErrorMessage("The book author is mandatory.");
                return;
            }

            context.Books.Add(newBook);
            context.SaveChanges();

            this.PanelCreateBook.Visible = false;
            this.LinkButtonShowCreatePanel.Visible = true;
        }

        protected void LinkButtonCancelCreating_Click(object sender, EventArgs e)
        {
            this.PanelCreateBook.Visible = false;
            this.PanelEditBook.Visible = false;
            this.LinkButtonShowCreatePanel.Visible = true;
        }

        protected void LinkButtonShowEditPanel_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == CommandEditBook)
            {
                int bookId = Convert.ToInt32(e.CommandArgument.ToString());
                this.HiddenField.Text = bookId.ToString();

                LibrarySystemEntities context = new LibrarySystemEntities();

                Book book = context.Books.Find(bookId);
                this.TextBoxEditedTitle.Text = book.Title;
                this.TextBoxEditedAuthor.Text = book.Author;
                this.TextBoxEditedISBN.Text = book.ISBN;
                this.TextBoxEditedWebSite.Text = book.ISBN;
                this.TextBoxEditedDescription.Text = book.Description;
                this.DropDownListEditedCategories.Text = book.Category.Name;
            }

            this.LinkButtonShowCreatePanel.Visible = false;
            this.PanelCreateBook.Visible = false;
            this.PanelEditBook.Visible = true;
        }

        protected void LinkButtonEditBook_Click(object sender, EventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();

            var selectedCategoryName = this.DropDownListEditedCategories.SelectedValue;
            var selectedCategoryId = context.Categories.Where(c => c.Name == selectedCategoryName).FirstOrDefault().CategoryId;

            int bookId = Convert.ToInt32(this.HiddenField.Text);
            Book editedBook = context.Books.Find(bookId);
            editedBook.Title = this.TextBoxEditedTitle.Text;
            editedBook.Author = this.TextBoxEditedAuthor.Text;
            editedBook.ISBN = this.TextBoxEditedISBN.Text;
            editedBook.WebSite = this.TextBoxEditedWebSite.Text;
            editedBook.Description = this.TextBoxEditedDescription.Text;
            editedBook.CategoryId = selectedCategoryId;

            if (editedBook.Title.Length >= MaxTitleLength)
            {
                ErrorSuccessNotifier.AddErrorMessage("The book title is too long, it has to be up to " + MaxTitleLength + " characters.");
                return;
            }

            if (editedBook.Author.Length >= MaxAuthorLength)
            {
                ErrorSuccessNotifier.AddErrorMessage("The book author(s) is too long, it has to be up to " + MaxAuthorLength + " characters.");
                return;
            }

            if (editedBook.ISBN.Length >= MaxISBNLength)
            {
                ErrorSuccessNotifier.AddErrorMessage("The book website is too long, it has to be up to " + MaxISBNLength + " characters.");
                return;
            }

            if (editedBook.WebSite.Length >= MaxWebSiteLength)
            {
                ErrorSuccessNotifier.AddErrorMessage("The book website is too long, it has to be up to " + MaxWebSiteLength + " characters.");
                return;
            }

            context.SaveChanges();

            this.PanelEditBook.Visible = false;
            this.PanelCreateBook.Visible = false;
            this.LinkButtonShowCreatePanel.Visible = true;
        }

        protected void LinkButtonCancelEditing_Click(object sender, EventArgs e)
        {
            this.LinkButtonShowCreatePanel.Visible = true;
            this.PanelCreateBook.Visible = false;
            this.PanelEditBook.Visible = false;
        }
    }
}