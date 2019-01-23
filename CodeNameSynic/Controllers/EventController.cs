using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeNameSynic.Models;

namespace CodeNameSynic.Controllers
{
    public class EventController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            Event eventFromDb = db.Events.Where(e => e.ID == id).FirstOrDefault();
            return View(eventFromDb);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(Event eventSubmittion)
        {
            try
            {
                db.Events.Add(eventSubmittion);
                db.SaveChanges();

                return RedirectToAction("Details", eventSubmittion.ID);
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            Event eventFromDb = db.Events.Where(e => e.ID == id).FirstOrDefault();
            return View(eventFromDb);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Event eventSubmittion)
        {
            try
            {
                Event eventFromDb = db.Events.Where(e => e.ID == id).FirstOrDefault();

                eventFromDb.Title = eventSubmittion.Title;
                eventFromDb.Description = eventSubmittion.Description;
                eventFromDb.Address = eventSubmittion.Address;
                eventFromDb.StartTime = eventSubmittion.StartTime;
                eventFromDb.EndTime = eventSubmittion.EndTime;
                eventFromDb.CategoryRefId = eventSubmittion.CategoryRefId;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                Event eventFromDb = db.Events.Where(e => e.ID == id).FirstOrDefault();
                return View(eventFromDb);
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            Event eventFromDb = db.Events.Where(e => e.ID == id).FirstOrDefault();
            return View(eventFromDb);
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Event eventFromDb = db.Events.Where(e => e.ID == id).FirstOrDefault();
                db.Events.Remove(eventFromDb);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                Event eventFromDb = db.Events.Where(e => e.ID == id).FirstOrDefault();
                return View(eventFromDb);
            }
        }
    }
}
