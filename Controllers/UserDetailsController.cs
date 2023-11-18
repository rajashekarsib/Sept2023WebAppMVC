using Sept2023WebAppMVC.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC.Controllers
{
    [OverrideActionFilters]
    public class UserDetailsController : Controller
    {
        // GET: UserDetails
        DbSept2023Entities db = new DbSept2023Entities();

       // [OverrideActionFilters]
        public ActionResult UserDeatilsList()
        {
            var data = db.UserDetails.ToList();
            return View(data);
        }

        public ActionResult AddUserDetails()
        {
            return View(new UserDetail());
        }

        [HttpPost]
        public ActionResult AddUserDetails(UserDetail userDetail)
        {
            db.UserDetails.Add(userDetail);
            db.SaveChanges();
            return RedirectToAction("UserDeatilsList");
        }

        
        public ActionResult EditUserDetails(int id)
        {

            var data = db.UserDetails.Where(u => u.Id == id).FirstOrDefault();
            if (data != null)
            {
                return View("AddUserDetails",data);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult EditUserDetails(UserDetail userDetail)
        {
            var data = db.UserDetails.Where(u => u.Id == userDetail.Id).FirstOrDefault();
            if (data != null)
            {
                data.Name = userDetail.Name;
                data.MobileNumber = userDetail.MobileNumber;
                data.IsActive = userDetail.IsActive;
                data.Email = userDetail.Email;
                data.DateOfBirth = userDetail.DateOfBirth;
                db.SaveChanges();
                return RedirectToAction("UserDeatilsList");
            }
            else
            {
                return HttpNotFound();
            }
        }

    
        public ActionResult DeleteUserDetails(int id)
        {
            var data = db.UserDetails.Where(u => u.Id == id).FirstOrDefault();
            if (data != null)
            {
                db.UserDetails.Remove(data);
                db.SaveChanges();
                return RedirectToAction("UserDeatilsList");
            }
            else
            {
                return HttpNotFound();
            }
        }

    }
}