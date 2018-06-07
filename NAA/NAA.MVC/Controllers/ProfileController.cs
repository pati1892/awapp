using NAA.Data;
using NAA.Service.IService;
using NAA.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.MVC.Controllers
{
    public class ProfileController : Controller
    {

        private IApplicantService service;

        public ProfileController()
        {
            service = new ApplicantService();
        }

        public ActionResult GetAllProfiles()
        {
            return View(service.GetAllApplicants());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Applicant applicant)
        {
            if (string.IsNullOrEmpty(applicant.ApplicantName))
            {
                ModelState.AddModelError("ApplicantName", "ApplicantName is required");
            }
            else if (string.IsNullOrEmpty(applicant.ApplicantAddress))
            {
                ModelState.AddModelError("ApplicantAddress", "ApplicantAddress is required");
            }
            else if (string.IsNullOrEmpty(applicant.Phone))
            {
                ModelState.AddModelError("Phone", "Phone is required");
            }
            else if (string.IsNullOrEmpty(applicant.Email))
            {
                ModelState.AddModelError("Email", "Email is required");
            }
            if (ModelState.IsValid)
            {
                service.AddApplicant(applicant);
                return RedirectToAction(nameof(GetAllProfiles));
            }
            return View();

           
            
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Applicant applicant = service.GetApplicant(id);
            return View(applicant);
        }

        [HttpPost]
        public ActionResult Edit(Applicant applicant)
        {
            try
            {
                if (string.IsNullOrEmpty(applicant.ApplicantName))
                {
                    ModelState.AddModelError("ApplicantName", "Name is required");
                }
                else if (string.IsNullOrEmpty(applicant.ApplicantAddress))
                {
                    ModelState.AddModelError("ApplicantAddress", "Adress is required");
                }
                else if (string.IsNullOrEmpty(applicant.Phone))
                {
                    ModelState.AddModelError("Phone", "Phone is required");
                }
                else if (string.IsNullOrEmpty(applicant.Email))
                {
                    ModelState.AddModelError("Email", "Email is required");
                }

                if (ModelState.IsValid)
                {
                    service.EditApplicant(applicant);
                    return RedirectToAction("Details", new { id = applicant.Id });
                }
                return View();

            }
            catch
            {
                return View();

            }
        }

        public ActionResult Details(int id)
        {
            Applicant applicant = service.GetApplicant(id);
            return View(applicant);
        }

        public ActionResult Delete(int id)
        {

            Applicant applicant = service.GetApplicant(id);
            return View(applicant);
        }

        [HttpPost]
        public ActionResult Delete(Applicant applicant) {

            service.DeleteApplicant(applicant.Id);
            return RedirectToAction(nameof(GetAllProfiles));
        }
    }
}