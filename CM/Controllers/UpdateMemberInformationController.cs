using CM.Models;
using CM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CM.Controllers
{
    [Authorize]
    public class UpdateMemberInformationController : Controller
    {
        //private ApplicationDbContext db = ApplicationDbContext();
        private IApplicationDbContext db;

        public UpdateMemberInformationController()
        {
            db = new ApplicationDbContext();
        }

        public UpdateMemberInformationController(IApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UpdateMemberInoformation
        public ActionResult Update(int memberId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(UpdateMemberInformation update)
        {
            if (ModelState.IsValid) { 
                db.UpdateMemberInformations.Add(update);
                var service = new MemberService(db);
                service.UpdateMemberInformation(update.MemberId);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}