using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Models
{
    public class TicketSearchViewModel
    {
        public static Expression<Func<Ticket, TicketSearchViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketSearchViewModel
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Author = ticket.Author.UserName,
                    Category = ticket.Category.Name,
                };
            }
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
    }
}