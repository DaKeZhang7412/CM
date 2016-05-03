using CareManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace CM.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        // GET: Member/Details
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            var member = db.Membership.Where(c=>c.ApplicationUserId == userId).First(); 
            return View(member);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsForAdmin(int id)
        {
            var userId = User.Identity.GetUserId();
            var member = db.Membership.Find(id);
            return View("Details", member);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult List()
        {
            return View(db.Membership.ToList());
        }

        public ActionResult MedFragMembersReport (int id)
        {
            var member = db.Membership.Find(id);
            return View(member.MedFragMemberReport.ToList());
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
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

        // GET: Member/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Member/Edit/5
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

        // GET: Member/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Member/Delete/5
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
    }
}
