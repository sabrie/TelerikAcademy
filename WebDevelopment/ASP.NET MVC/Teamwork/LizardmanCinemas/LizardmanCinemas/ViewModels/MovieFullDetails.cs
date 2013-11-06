using LizardmanCinemas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LizardmanCinemas.ViewModels
{
    public class MovieFullDetails
    {
        public static Expression<Func<Movie, MovieFullDetails>> FromMovie
        {
            get
            {
                return movie => new MovieFullDetails()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Director = movie.Director,
                    Year = movie.Year,
                    Actors = movie.Actors,
                    Duration = movie.Duration,
                    Trailer = movie.Trailer,
                    Poster = movie.Poster,
                    Description = movie.Description,
                    Country = movie.Country,
                    Category = movie.Category,
                    ParentsGuide = movie.ParentsGuide,
                    Votes = movie.Votes,
                    Comments = movie.Comments.Select(comment => new CommentViewModel()
                    {
                        Author = comment.User.UserName,
                        AuthorId = comment.User.Id,
                        CommentText = comment.CommentText,
                        CreatedOn = comment.CreatedOn
                    }).ToList()

                };
            }
        }
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual Director Director { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

        public virtual ICollection<CommentViewModel> Comments { get; set; }

        public int Duration { get; set; }

        public string Trailer { get; set; }

        public string Poster { get; set; }

        public string Description { get; set; }

        public  virtual Country Country { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ParentsGuide ParentsGuide { get; set; }
    }
}