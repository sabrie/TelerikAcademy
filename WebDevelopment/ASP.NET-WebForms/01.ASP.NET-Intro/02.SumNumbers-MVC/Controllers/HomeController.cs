using _02.SumNumbers_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02.SumNumbers_MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Summator summator = new Summator();
            return View(summator);
        }

        [HttpPost]
        public ActionResult Index(Summator summator) 
        {
            summator.Sum = summator.FirstNumber + summator.SecondNumber;
            return View(summator);
        }
    }
}