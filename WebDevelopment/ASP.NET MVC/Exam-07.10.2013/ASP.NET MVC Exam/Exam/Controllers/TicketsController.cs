using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exam.Models;
using Exam.Data;
using Microsoft.AspNet.Identity;
using System.Net.Http;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Exam.Controllers
{
    public class TicketsController : BaseController
    {
        private IQueryable<TicketsListViewModel> GetAllTickets()
        {
            var data = this.Data.Tickets.All().Select(TicketsListViewModel.FromTicket);
            return data;
        }

        public JsonResult GetTickets([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.GetAllTickets().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult List()
        {
            return View();
        }

        // GET: /Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ticket = this.Data.Tickets.All().Where(x => x.Id == id)
                .Select(TicketDetailsViewModel.FromTicket).FirstOrDefault();

            if (ticket == null)
            {
                return HttpNotFound();
            }


            return View(ticket);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmitCommentViewModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();

                this.Data.Comments.Add(new Comment()
                {
                    UserId = userId,
                    Content = commentModel.Comment,
                    TicketId = commentModel.TicketId,
                });

                this.Data.SaveChanges();

                var viewModel = new CommentViewModel { Username = username, Content = commentModel.Comment };
                
                return PartialView("_CommentPartial", viewModel);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        [Authorize]
        // GET: /Ticketss/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(this.Data.Users.All().ToList(), "Id", "UserName");
            ViewBag.CategoryId = new SelectList(this.Data.Categories.All().ToList(), "Id", "Name");
            
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTicketViewModel ticket)
        {
            var username = this.User.Identity.GetUserName();
            var userId = this.User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                Ticket newTicket = new Ticket()
                {
                    Title = ticket.Title,
                    AuthorId = userId,
                    CategoryId = ticket.CategoryId,
                    Priority = ticket.Priority,
                    ScreenshotUrl = ticket.ScreenshotUrl,
                    Description = ticket.Description
                };
                
                this.Data.Tickets.Add(newTicket);
                this.Data.SaveChanges();
                return RedirectToAction("List");
            }

            List<Priority> priorities = new List<Priority>{Priority.Low, Priority.Medium, Priority.High};
            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "Id", "Name", ticket.CategoryId);
            ViewBag.Priority = new SelectList(priorities, "Key");

            return View(ticket);
        }

        public ActionResult Search(SubmitSearchModel searchModel)
        {
            var result = this.Data.Tickets.All();

            if (searchModel.TicketSearch != null)
            {
                result = result.Where(t => t.Category.Name == searchModel.TicketSearch);
            }            

            var viewModel = result.Select(TicketSearchViewModel.FromTicket);
            
            return View(viewModel);
        }

        public JsonResult GetTicketsCategoryData(string text)
        {
            var result = this.Data.Categories
                .All()
                .Select(c => new
                {
                    Name = c.Name
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
