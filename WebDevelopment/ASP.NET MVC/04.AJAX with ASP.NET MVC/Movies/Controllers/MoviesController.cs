using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movies.Models;
using Movies.Data;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesContext db = new MoviesContext();

        // GET: /Movies/
        public ActionResult Index()
        {
            if (!Request.IsAjaxRequest())
            {
                return View(db.Movies.ToList());
            }
            
            return null;
        }

        public ActionResult IndexPartial()
        {
            return PartialView("_IndexMovie", db.Movies.ToList());
        }

        // GET: /Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DetailsMovie", movie);
        }

        // GET: /Movies/Create
        public ActionResult Create()
        {
            ViewBag.MaleActors = db.Actors.ToList().Where(a => a.Gender == Gender.Male).Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
            ViewBag.FemaleActors = db.Actors.ToList().Where(a => a.Gender == Gender.Female).Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
            ViewBag.Studios = db.Studios.ToList().Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });

            return PartialView("_CreateMovie");
        }

        // POST: /Movies/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel model)
        {
            var maleActor = db.Actors.Find(model.LeadingMaleRoleId);
            var femaleActor = db.Actors.Find(model.LeadingFemaleRoleId);
            var studio = db.Studios.Find(model.StudioId);

            if (maleActor != null && femaleActor != null && studio != null)
            {
                var movie = new Movie();
                movie.Title = model.Title;
                movie.Year = model.Year;
                movie.Director = model.Director;
                movie.LeadingMaleRole = maleActor;
                movie.LeadingFemaleRole = femaleActor;
                movie.Studio = studio;

                if (ModelState.IsValid)
                {
                    db.Movies.Add(movie);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.MaleActors = db.Actors.ToList().Where(a => a.Gender == Gender.Male).Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
            ViewBag.FemaleActors = db.Actors.ToList().Where(a => a.Gender == Gender.Female).Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
            ViewBag.Studios = db.Studios.ToList().Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });

            return PartialView("_CreateMovie", model);
        }

        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            ViewBag.MaleActors = db.Actors.ToList().Where(a => a.Gender == Gender.Male).Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
            ViewBag.FemaleActors = db.Actors.ToList().Where(a => a.Gender == Gender.Female).Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
            ViewBag.Studios = db.Studios.ToList().Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });

            var movieViewModel = new MovieViewModel()
            {
                Title = movie.Title,
                Director = movie.Director,
                Year = movie.Year,
                LeadingFemaleRoleId = movie.LeadingFemaleRole.Id,
                LeadingMaleRoleId = movie.LeadingMaleRole.Id,
                StudioId = movie.Studio.Id
            };

            return PartialView("_EditMovie", movieViewModel);
        }

        // POST: /Movies/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieViewModel model)
        {
            var maleActor = db.Actors.Find(model.LeadingMaleRoleId);
            var femaleActor = db.Actors.Find(model.LeadingFemaleRoleId);
            var studio = db.Studios.Find(model.StudioId);

            if (maleActor != null && femaleActor != null && studio != null)
            {
                var movie = new Movie();
                movie.Id = model.Id;
                movie.Title = model.Title;
                movie.Year = model.Year;
                movie.Director = model.Director;
                movie.LeadingMaleRole = maleActor;
                movie.LeadingFemaleRole = femaleActor;
                movie.Studio = studio;
                if (ModelState.IsValid)
                {
                    db.Entry(movie).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.MaleActors = db.Actors.ToList().Where(a => a.Gender == Gender.Male).Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
            ViewBag.FemaleActors = db.Actors.ToList().Where(a => a.Gender == Gender.Female).Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() });
            ViewBag.Studios = db.Studios.ToList().Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() });

            return PartialView("_EditMovie", model);
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeleteMovie", movie);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
