using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LizardmanCinemas.Data;
using LizardmanCinemas.Models;
using LizardmanCinemas.ViewModels;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Microsoft.AspNet.Identity;

namespace LizardmanCinemas.Controllers
{
    public class MoviesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Movies/
        public ActionResult Index()
        {
            return View(db.Movies.Select(MovieShortViewModel.FromMovie));
        }

        public ActionResult ReadMovies([DataSourceRequest]DataSourceRequest request)
        {
            var movies = db.Movies.Select(MovieShortViewModel.FromMovie);

            DataSourceResult result = movies.ToDataSourceResult(request);

            return Json(result);
        }

        // For Search Result Window
        // GET: /Directors/DetailsView/5
        public ActionResult DetailsView(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Include(d => d.Category).FirstOrDefault(d => d.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var model = new MovieDetails()
            {
                Title = movie.Title,
                Id = movie.Id,
                Poster = movie.Poster,
                CategoryName = movie.Category.Name,
                Year = movie.Year,
                DetailsUrl = "/Movies/Details/" + movie.Id,
            };

            return PartialView("_MovieDetailsPopUp", model);
        }

        // GET: /Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Include("Votes").Include("Votes.User").FirstOrDefault(x => x.Id == id);

            var model = new MovieFullDetails
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
            
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(SubmitCommentModel commentModel)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            
            if (ModelState.IsValid)
            {
                Movie movie = db.Movies.FirstOrDefault(x => x.Id == commentModel.MovieId);
                var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();

                Comment newComment = new Comment()
                {
                    User = user,
                    CommentText = commentModel.CommentText,
                    Movie = movie,
                    CreatedOn = DateTime.Now
                };

                db.Comments.Add(newComment);
                db.SaveChanges();

                var viewModel = new CommentViewModel()
                {
                    Author = newComment.User.UserName,
                    AuthorId = newComment.User.Id,
                    CommentText = newComment.CommentText,
                    CreatedOn = newComment.CreatedOn
                };

                return PartialView("_CommentPartial", viewModel);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VoteUp(int? id)
        {
            return Votes(id, 1);
        }

        private ActionResult Votes(int? id, int islLke)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var user = db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            if (user == null)
            {
                return HttpNotFound();
            }

            var vote = db.Votes.FirstOrDefault(x => x.User.UserName == User.Identity.Name && x.MovieId == id);
            if (vote == null)
            {
                vote = new Vote();
            }

            vote.UserId = User.Identity.GetUserId();
            vote.Movie = movie;
            vote.IsLike = islLke;

            db.Votes.Add(vote);
            db.SaveChanges();

            var model = new MovieFullDetails()
            {
                Id = movie.Id,
                Votes = movie.Votes
            };

            return PartialView("_VotesPartial", model);
            //return RedirectToAction("Details/" + movie.Id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VoteDown(int? id)
        {
            return Votes(id, -1);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
