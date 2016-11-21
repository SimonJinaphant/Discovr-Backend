using DiscovrWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                TempData["ModifyEvent"] = result;
                return RedirectToAction("ModifyEvent");
            }
            catch
            {
                return RedirectToAction("OnFailure");
            }
        }

        public ActionResult ModifyEvent()
        {
            try
            {
                var eventmodel = TempData["ModifyEvent"];
                return View(eventmodel);
            }
            catch
            {
                return RedirectToAction("OnFailure");
            }
        }

        [HttpPost]
        public ActionResult Update(Event updatedEvent)
        {
            updatedEvent.LastUpdated = DateTime.Now;
            db.Events.Attach(updatedEvent);
            db.Entry(updatedEvent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                TempData["GUID"] = updatedEvent.Guid;
                return RedirectToAction("OnSuccess");
            }
            catch (Exception e)
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
                TempData["GUID"] = newEvent.Guid;
                return RedirectToAction("OnSuccess");
            }
            catch
            {
                return RedirectToAction("OnFailure");
            }
        }

        public ActionResult OnSuccess()
        {
            var eventGuid = TempData["GUID"];
            return View();
        }

        public ActionResult OnFailure()
        {
            return View();
        }

        public ActionResult Modify()
        {
            return View();
        }
    }
}