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
    public class ReviewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        // GET: Review/Details/5
        public ActionResult Details(int? id)
        {
            Rating reviewFromDb = db.Ratings.Where(r => r.ID == id).SingleOrDefault();
            return View(reviewFromDb);
        }

        // GET: Review/Create
        public ActionResult Create(int? id)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            SynicUser loggedInUser = db.SynicUsers.Where(u => u.ApplicationUserRefId == user.Id).SingleOrDefault();
            Event eventFromDb = db.Events.Where(e => e.ID == id).SingleOrDefault();
            if (eventFromDb.UserRefId != loggedInUser.ID)
            {
                return View(eventFromDb.ID);
            }
            else
            {
                // users should not be able to rate their own event
                return View("Index", "Regular");
            }
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(Rating review, int? id)
        {
            try
            {
                var userID = User.Identity.GetUserId();
                SynicUser userFromDb = db.SynicUsers.Where(u => u.ApplicationUserRefId == userID).SingleOrDefault();
                review.SynicUserRefId = userFromDb.ID;
                review.SynicUser = userFromDb;
                db.Ratings.Add(review);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = review.ID });
            }
            catch
            {
                return View(review);
            }
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int? id)
        {
            Rating reviewFromDb = db.Ratings.Where(r => r.ID == id).SingleOrDefault();
            return View(reviewFromDb);
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Rating review)
        {
            try
            {
                Rating reviewFromDb = db.Ratings.Where(r => r.ID == id).SingleOrDefault();
                reviewFromDb.Description = review.Description;
                reviewFromDb.RatingNumber = review.RatingNumber;
                db.SaveChanges();

                return RedirectToAction("Details", new { id = reviewFromDb.ID });
            }
            catch
            {
                return View(review);
            }
        }

        // GET: Review/Delete/5
        public ActionResult Delete(int? id)
        {
            Rating reviewFormDb = db.Ratings.Where(r => r.ID == id).SingleOrDefault();
            return View(reviewFormDb);
        }

        // POST: Review/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                Rating reviewFormDb = db.Ratings.Where(r => r.ID == id).SingleOrDefault();
                db.Ratings.Remove(reviewFormDb);
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
                return View();
            }
        }

        public ActionResult List(int? eventId)
        {
            
            return View();
        }
    }
}
