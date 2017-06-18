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
                using (Repository<Musicians> artistRepo = new Repository<Musicians>(context))
                {
                    List<Events> listOfEvents = repo.GetAll().OrderByDescending(o => o.Id).Take(10).ToList();
                    List<Musicians> listOfArtists = artistRepo.GetAll().OrderByDescending(o => o.Id).Take(10).ToList();
                    HomeViewModel model = new HomeViewModel
                    {
                        Events = listOfEvents,
                        Musicians = listOfArtists
                    };
                    return View(model);
                }
            }     
        }

        public ActionResult About()
        {
            ViewBag.Message = "Who are we?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How can we help?";

            return View();
        }
    }
}