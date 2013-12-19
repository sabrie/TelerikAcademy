using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Models
{
    public class TicketDetailsViewModel
    {
        public static Expression<Func<Ticket, TicketDetailsViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketDetailsViewModel
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    AuthorName = ticket.Author.UserName,
                    CategoryName = ticket.Category.Name,
                    Priority = ticket.Priority,
                    ScreenshotUrl = ticket.ScreenshotUrl,
                    Description = ticket.Description,
                    Comments = ticket.Comments.AsQueryable().Select(CommentViewModel.FromComment)
                };
            }
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string CategoryName { get; set; }

        public Priority Priority { get; set; }

        public string ScreenshotUrl { get; set; }

        public string Description { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}