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
        private ApplicationDbContext db = new ApplicationDbContext();
        private List<string> startTime = new List<string>() { "72 hours", "48 hours", "24 hours", "12 hours", "6 hours", "3 hours", "1 hour", "45 minutes", "30 minutes", "15 minutes", "10 minutes", "5 minutes" };
        private List<string> endTime = new List<string>() { "72 hours", "48 hours", "24 hours", "12 hours", "6 hours", "3 hours", "1 hour", "45 minutes", "30 minutes", "15 minutes", "10 minutes", "5 minutes" };
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        // GET: Event/Details/5
        public ActionResult Details(int? id)
        {
            Event eventFromDb = db.Events.Where(e => e.ID == id).FirstOrDefault();
            SynicUser userFromDb = db.SynicUsers.Where(u => u.ID == eventFromDb.UserRefId).SingleOrDefault();
            eventFromDb.User = userFromDb;

            eventFromDb.TotalRating = RatingCalculation(eventFromDb.ID);

            return View("Event", eventFromDb);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
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

                return RedirectToAction("Details", new { id = eventModel.ID });
            }
            catch
            {
                ViewBag.StartTime = new SelectList(startTime);
                ViewBag.EndTime = new SelectList(endTime);
                ViewBag.CategoryList = new SelectList(db.Categories.Select(c => c.Title).ToList());

                return View(eventSubmittion);
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int? id)
        {
            Event eventFromDb = db.Events.Where(e => e.ID == id).FirstOrDefault();
            return View(eventFromDb);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Event eventSubmittion)
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

                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                var userRoleJunktion = user.Roles.Where(r => r.UserId == user.Id).SingleOrDefault();
                var role = db.Roles.Where(r => r.Id == userRoleJunktion.RoleId).SingleOrDefault();
                if (role.Name == "Regular")
                {
                    return RedirectToAction("Index", "Regular");
                }
                else if (role.Name == "Moderator")
                {
                    return RedirectToAction("Index", "Moderator");
                }
                else
                {
                    // Something went wrong here and the user was either not signed in or has no role assigned to them
                    // either way, return them to the home page.
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                Event eventFromDb = db.Events.Where(e => e.ID == id).FirstOrDefault();
                return View(eventFromDb);
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int? id)
        {
            Event eventFromDb = db.Events.Where(e => e.ID == id).FirstOrDefault();
            return View(eventFromDb);
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                Event eventFromDb = db.Events.Where(e => e.ID == id).FirstOrDefault();
                db.Events.Remove(eventFromDb);
                db.SaveChanges();

                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                var userRoleJunktion = user.Roles.Where(r => r.UserId == user.Id).SingleOrDefault();
                var role = db.Roles.Where(r => r.Id == userRoleJunktion.RoleId).SingleOrDefault();
                if (role.Name == "Regular")
                {
                    return RedirectToAction("Index", "Regular");
                }
                else if (role.Name == "Moderator")
                {
                    return RedirectToAction("Index", "Moderator");
                }
                else
                {
                    // Something went wrong here and the user was either not signed in or has no role assigned to them
                    // either way, return them to the home page.
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                Event eventFromDb = db.Events.Where(e => e.ID == id).FirstOrDefault();
                return View(eventFromDb);
            }
        }

        private double RatingCalculation(int id)
        {
            var ratingsFromDb = db.Ratings.Where(r => r.Event.ID == id).ToList();
            double total = 0;
            foreach(var rating in ratingsFromDb)
            {
                total += rating.RatingNumber;
            }
            return total;
        }
    }
}
