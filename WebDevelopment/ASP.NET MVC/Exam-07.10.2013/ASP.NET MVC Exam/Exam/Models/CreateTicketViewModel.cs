using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.Models
{
    public class CreateTicketViewModel
    {
        [Required(ErrorMessage = "Title field is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ticket title should be between {1} and {2} characters")]
        [ShouldNotContainString("bug", ErrorMessage = "The word \"bug\" should not be user in the title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Category field is required")]
        public int CategoryId { get; set; }
        
        [Required(ErrorMessage="Priority field is required")]
        [DataType("Priority")]
        public Priority Priority { get; set; }

        [Display(Name="Screenshot URL")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "The screenshpt url should be between {1} and {2} characters")]
        public string ScreenshotUrl { get; set; }

        //[Column(TypeName = "ntext")]
        public string Description { get; set; }
    }
}