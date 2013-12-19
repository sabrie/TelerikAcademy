using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.Models
{
    public class SubmitCommentViewModel
    {
        [Required]
        public string Comment { get; set; }

        [Required]
        public int TicketId { get; set; }
    }
}