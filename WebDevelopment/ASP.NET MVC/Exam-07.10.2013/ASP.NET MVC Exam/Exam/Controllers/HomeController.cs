using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (this.HttpContext.Cache["HomePageTickets"] == null)
            {
                var listOfTickets = this.Data.Tickets.All()
                    .OrderByDescending(t => t.Comments.Count())
                    .Take(6)
                    .Select(t => new TicketViewModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        AuthorName = t.Author.UserName,
                        CategoryName = t.Category.Name,
                        CommentsNumber = t.Comments.Count()
                    });

                this.HttpContext.Cache.Add("HomePageTickets", listOfTickets.ToList(), null, DateTime.Now.AddHours(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache["HomePageTickets"]);
        }
    }
}