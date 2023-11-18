using Sept2023WebAppMVC.Models;
using Sept2023WebAppMVC.Repostitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sept2023WebAppMVC.Controllers
{
    public class PersonDetailsController : Controller
    {
        PersonDetailsRepository personDetailsRepository = new PersonDetailsRepository();
        // GET: PersonDetails
        public ActionResult Save()
        {
            GenderRepository genderRepository=new GenderRepository() ;
            List<GenderModel> genderList = genderRepository.GetGenders();
            ViewBag.GenderData = new SelectList(genderList, "ID", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult Save(PersonDetailsModel personDetailsModel)
        {
            GenderRepository genderRepository = new GenderRepository();
            List<GenderModel> genderList = genderRepository.GetGenders();
            ViewBag.GenderData = new SelectList(genderList, "ID", "Name");

            bool result = personDetailsRepository.AddPersonDetails(personDetailsModel);

            ViewBag.result = result;
            return RedirectToAction("GetPersonDetails");
        }

        public ActionResult GetPersonDetails()
        {
            var personData = personDetailsRepository.GetPersonDetails();
            return View(personData);
        }

        public ActionResult Edit(int? id)
        {
            //int number = 10; //doesn't accept null value
            //number = null;

            //int? num2 = 5; // nullable type int.. it allows the null value
            //num2 = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            GenderRepository genderRepository = new GenderRepository();
            List<GenderModel> genderList = genderRepository.GetGenders();
            ViewBag.GenderData = new SelectList(genderList, "ID", "Name");

            
            var person = personDetailsRepository.GetPersonDetailsById(id);


            if (person == null)
            {
                return HttpNotFound();
            }
            else
            {
                person.DateOfBirth = Convert.ToDateTime(person.DateOfBirth.Date.ToString("dd/MM/yyyy"));
                return View(person);
            }

            
        }

        [HttpPost]
        public ActionResult Edit(PersonDetailsModel personDetailsModel)
        {
            bool result = personDetailsRepository.UpdatePersonDetails(personDetailsModel);
            if (result)
            {
                return RedirectToAction("GetPersonDetails");
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult DeletePersonDetails(int id)
        {

            bool status = personDetailsRepository.DeletePersonDetails(id);
            if (status)
                return RedirectToAction("GetPersonDetails");
            else
                return HttpNotFound();
            
        }
    }
}