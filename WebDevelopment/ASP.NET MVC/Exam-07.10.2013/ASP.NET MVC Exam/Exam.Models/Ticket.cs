using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ticket title should be between {1} and {2} characters")]
        [ShouldNotContainString("bug", ErrorMessage="The word bug should not be user in the title")]
        public string Title { get; set; }

        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }


        [Display(Name="Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        //[DataType("Priority")]
        public Priority Priority { get; set; }

        [StringLength(150, MinimumLength = 3, ErrorMessage = "The screenshot url should be between {1} and {2} characters")]
        public string ScreenshotUrl { get; set; }

        //[Column(TypeName = "ntext")]
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
