using NAA.Service.IService;
using NAA.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.MVC.Controllers
{
    public class ApplicantController : Controller
    {

        private IApplicantService service;

        public ApplicantController()
        {
            service = new ApplicantService();
        }

        public ActionResult GetAllApplicants()
        {
            return View(service.GetAllApplicants());
        }


        // GET: Applicant
        public ActionResult Index()
        {
            return View();
        }
    }
}