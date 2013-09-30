using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Movie
    {
        [ScaffoldColumn(false)] 
        public int Id { get; set; }

        [Required(ErrorMessage = "The title of the movie is required.")]
        public string Title { get; set; }

        public string Director { get; set; }

        [Required(ErrorMessage = "The year of the movie is required.")]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "The year is not in a valid format.")]
        public int Year { get; set; }

        public virtual Studio Studio { get; set; }

        [Display(Name = "Leading Male Role")]
        public virtual Actor LeadingMaleRole { get; set; }

        [Display(Name = "Leading Female Role")]
        public virtual Actor LeadingFemaleRole { get; set; }
    }
}
