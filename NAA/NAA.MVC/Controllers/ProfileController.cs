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
        public void Add(Applicant applicant)
        {
            service.AddApplicant(applicant);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Applicant applicant = service.GetApplicant(id);
            return View(applicant);
        }

        [HttpPost]
        public void Update(Applicant applicant)
        {
            service.EditApplicant(applicant);
        }

        public ActionResult Details(int id)
        {
            Applicant applicant = service.GetApplicant(id);
            return View(applicant);
        }

    }
}