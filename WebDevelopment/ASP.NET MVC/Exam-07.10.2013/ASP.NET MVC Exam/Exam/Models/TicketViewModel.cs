using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string CategoryName { get; set; }

        public int CommentsNumber { get; set; }
    }
}