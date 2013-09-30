using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Movies.Models
{
    public class MovieViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The title of the movie is required.")]

        public string Title { get; set; }

        public string Director { get; set; }

        [Required(ErrorMessage = "The year of the movie is required.")]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "The year is not in a valid format.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "The studio of the movie is required.")]
        public int StudioId { get; set; }

        [Display(Name="Leading Male Role")]
        [Required(ErrorMessage = "The leading male role of the movie is required.")]
        public int LeadingMaleRoleId { get; set; }

        [Display(Name = "Leading Female Role")]
        [Required(ErrorMessage = "The leading female role of the movie is required.")]
        public int LeadingFemaleRoleId { get; set; }
    }
}