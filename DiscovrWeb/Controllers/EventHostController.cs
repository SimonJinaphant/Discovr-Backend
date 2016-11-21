using DiscovrWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscovrWeb.Controllers
{
    public class EventHostController : Controller
    {
        private DiscovrWebContext db = new DiscovrWebContext();

        // GET: EventHost
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event newEvent)
        {
            // Probably a better way to auto increment ID....
            newEvent.Id = db.Events.Max(x => x.Id) + 1;
            db.Events.Add(newEvent);
            db.SaveChanges();
            return RedirectToAction("OnSuccess");
        }

        public ActionResult OnSuccess()
        {
            return View();
        }
    }
}