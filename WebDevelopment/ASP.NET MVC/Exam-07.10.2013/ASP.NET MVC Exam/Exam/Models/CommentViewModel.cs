using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Models
{
    public class CommentViewModel
    {
        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get
            {
                return comment => new CommentViewModel
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    Username = comment.User.UserName
                };
            }
        }
        public int Id { get; set; }

        public string Content { get; set; }

        public string Username { get; set; }
    }
}