using LizardmanCinemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LizardmanCinemas.ViewModels
{
    /// <summary>
    /// For Movie details
    /// </summary>
    public class CommentViewModel
    {
        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return comment => new CommentViewModel()
                {
                    Author = comment.User.UserName,
                    AuthorId = comment.User.Id,
                    CommentText = comment.CommentText,
                    CreatedOn = comment.CreatedOn 
                };
            }
        }
        public int Id { get; set; }
        public string Author { get; set; }
        public string AuthorId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}