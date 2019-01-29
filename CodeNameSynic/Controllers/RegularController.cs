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
    public class RegularController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private List<string> startTime = new List<string>() { "72 hours", "48 hours", "24 hours", "12 hours", "6 hours", "3 hours", "1 hour", "45 minutes", "30 minutes", "15 minutes", "10 minutes", "5 minutes" };
        private List<string> endTime = new List<string>() { "72 hours", "48 hours", "24 hours", "12 hours", "6 hours", "3 hours", "1 hour", "45 minutes", "30 minutes", "15 minutes", "10 minutes", "5 minutes" };

        // GET: Regular
        public ActionResult Index()
        {
            UserAndEventsModel model = new UserAndEventsModel();

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            model.User = db.SynicUsers.Where(u => u.ApplicationUserRefId == user.Id).SingleOrDefault();
            try
            {
                foreach (var category in model.User.UserPreferences.FollowedCategories)
                {
                    model.Events = db.Events.Where(e => e.Category.ID == category.ID).ToList();
                }
                ViewBag.TimeDropDown = new SelectList(startTime);
                ViewBag.CategoryDropDown = new SelectList(db.Categories.Select(c => c.Title).ToList());
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Regular/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Regular/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Regular/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Regular/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Regular/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Regular/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Regular/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Category(string category)
        {
            Category selectedCategory = db.Categories.Where(c => c.Title == category).SingleOrDefault();
            List<Event> EventList = db.Events.Where(e => e.CategoryRefId == selectedCategory.ID).ToList();
            ViewBag.EventList = new SelectList(EventList);

            return View(selectedCategory);
        }

        //private List<Event> eventQuery(int ID)
        //{
        //    var eventQuery = db.Events.Where(e => e.Category.ID == ID).ToList();
        //    return eventQuery;
        //}
    }
}
