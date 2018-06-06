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
            service.AddApplicant(applicant);
            return RedirectToAction(nameof(GetAllProfiles));
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
                service.EditApplicant(applicant);
                return RedirectToAction("Details", new { id = applicant.Id });
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