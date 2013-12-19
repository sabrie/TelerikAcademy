using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Models
{
    public class TicketsListViewModel
    {
        public static Expression<Func<Ticket, TicketsListViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketsListViewModel
                {
                    Title = ticket.Title,
                    Author = ticket.Author.UserName,
                    Category = ticket.Category.Name,
                    Priority = ticket.Priority                    
                };
            }
        }

        public string Title { get; set; }
        public string Category { get; set; }

        public string Author { get; set; }

        public Priority Priority { get; set; }
    }
}