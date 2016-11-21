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
        public ActionResult GetEvent(Event query)
        {
            try
            {
                var result = db.Events.Where(x => x.Guid.Equals(query.Guid)).First();
                return RedirectToAction("ModifyEvent", new { result.Id });
            }
            catch
            {
                return RedirectToAction("OnFailure");
            }
        }

        public ActionResult ModifyEvent(int id)
        {
            try
            {
                var result = db.Events.FindAsync(id);
                return View(result);
            }
            catch
            {
                return RedirectToAction("OnFailure");
            }
        }

        [HttpPost]
        public ActionResult Update(Event updatedEvent)
        {
            updatedEvent.LastUpdated = DateTime.Today;
            try
            {
                db.SaveChanges();
                return RedirectToAction("OnSuccess");
            }
            catch
            {
                return RedirectToAction("OnFailure");
            }
        }

        [HttpPost]
        public ActionResult Create(Event newEvent)
        {
            // Probably a better way to auto increment ID....
            newEvent.Id = db.Events.Max(x => x.Id) + 1;
            newEvent.Guid = Guid.NewGuid();
            newEvent.LastUpdated = DateTime.Today;
            db.Events.Add(newEvent);
            try
            {
                db.SaveChanges();
                return RedirectToAction("OnSuccess");
            }
            catch
            {
                return RedirectToAction("OnFailure");
            }
        }

        public ActionResult OnSuccess()
        {
            return View();
        }

        public ActionResult OnFailure()
        {
            return View();
        }
    }
}