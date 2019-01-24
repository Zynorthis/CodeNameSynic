using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeNameSynic.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

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
            return View("Event", eventFromDb);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            List<string> startTime = new List<string>() { "72 hours", "48 hours", "24 hours", "12 hours", "6 hours", "3 hours", "1 hour", "45 minutes", "30 minutes", "15 minutes", "10 minutes", "5 minutes" };
            List<string> endTime = new List<string>() { "72 hours", "48 hours", "24 hours", "12 hours", "6 hours", "3 hours", "1 hour", "45 minutes", "30 minutes", "15 minutes", "10 minutes", "5 minutes" };
            ViewBag.StartTime = new SelectList(startTime);
            ViewBag.EndTime = new SelectList(endTime);
            ViewBag.CategoryList = new SelectList(db.Categories.Select(c => c.Title).ToList());
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(CategoryAndEventModel eventSubmittion)
        {
            try
            {
                var userID = User.Identity.GetUserId();
                SynicUser user = db.SynicUsers.Where(u => u.ApplicationUserRefId == userID).SingleOrDefault();

                Event eventModel = new Event();
                eventModel = eventSubmittion.Event;
                int categoryIdFromDb = db.Categories.Where(c => c.Title == eventSubmittion.Category.Title).Select(c => c.ID).SingleOrDefault();

                eventModel.CategoryRefId = categoryIdFromDb;
                eventModel.UserRefId = user.ID;

                db.Events.Add(eventModel);
                db.SaveChanges();

                return RedirectToAction("Details", eventModel.ID);
            }
            catch
            {
                List<string> startTime = new List<string>() { "72 hours", "48 hours", "24 hours", "12 hours", "6 hours", "3 hours", "1 hour", "45 minutes", "30 minutes", "15 minutes", "10 minutes", "5 minutes" };
                List<string> endTime = new List<string>() { "72 hours", "48 hours", "24 hours", "12 hours", "6 hours", "3 hours", "1 hour", "45 minutes", "30 minutes", "15 minutes", "10 minutes", "5 minutes" };
                ViewBag.StartTime = new SelectList(startTime);
                ViewBag.EndTime = new SelectList(endTime);
                ViewBag.CategoryList = new SelectList(db.Categories.Select(c => c.Title).ToList());

                return View(eventSubmittion);
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
