using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeNameSynic.Models;

namespace CodeNameSynic.Controllers
{
    public class RegularController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Regular
        public ActionResult Index(SynicUser user)
        {
            //List<Event> recommendedEvents = new List<Event>();
            //foreach(var category in user.UserPreferences.FollowedCategories)
            //{
            //    List<Event> popularEvents = eventQuery(category.ID);
            //    foreach(var item in popularEvents)
            //    {
            //        recommendedEvents.Add(item);
            //    }
            //}
            //return View(recommendedEvents);
            return View();
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

        //private List<Event> eventQuery(int ID)
        //{
        //    var eventQuery = db.Events.Where(e => e.Category.ID == ID).ToList();
        //    return eventQuery;
        //}
    }
}
