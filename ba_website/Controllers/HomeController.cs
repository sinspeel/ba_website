using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ba_website.model;
using ba_website.database;
using ba_website.Repository;
using ba_website.Models;

namespace ba_website.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context = new DataContext();
        public ActionResult Index()
        {
            using (Repository<Events> repo = new Repository<Events>(context))
            {
                List<Events> listOfEvents = repo.GetAll().OrderByDescending(o => o.Id).Take(10).ToList();
                HomeViewModel model = new HomeViewModel
                {
                    Events = listOfEvents
                };
                return View(model);
            }     
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}