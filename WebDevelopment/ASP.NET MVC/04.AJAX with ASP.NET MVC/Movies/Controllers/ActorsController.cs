﻿using System;
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
    public class ActorsController : Controller
    {
        private MoviesContext db = new MoviesContext();

        // GET: /Actors/
        public ActionResult Index()
        {
            if (!Request.IsAjaxRequest())
            {
                return View(db.Actors.ToList());
            }

            return null;
        }

        public ActionResult IndexPartial()
        {
            return PartialView("_IndexActors", db.Actors.ToList());
        }

        // GET: /Actors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }

            return PartialView("_DetailsActor", actor);
        }

        // GET: /Actors/Create
        public ActionResult Create()
        {
            return PartialView("_CreateActor");
        }

        // POST: /Actors/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView("_CreateActor", actor);
        }

        // GET: /Actors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }

            return PartialView("_EditActor", actor);
        }

        // POST: /Actors/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView("_EditActor", actor);
        }

        // GET: /Actors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeleteActor", actor);
        }

        // POST: /Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = db.Actors.Find(id);
            db.Actors.Remove(actor);
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