using NAA.CourseService.Bean;
using NAA.CourseService.IService;
using NAA.Data;
using NAA.Data.Enum;
using NAA.Service.IService;
using NAA.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAA.MVC.Controllers
{
    public class CourseController : Controller
    {

        ICourseService service;
        IApplicationService appService;

        public CourseController()
        {
            service = new CourseService.Service.CourseService();
            appService = new ApplicationService();
        }

        // GET: Course
        public ActionResult Index(int id)
        {
            ViewBag.applicantId = id;
            ViewBag.ToManyApplications = appService.GetApplications(id).Count >= 5;
            ViewBag.ToManyApplicationsMessage = "You are already applied to 5 courses.";
            return View();
        }
        public ActionResult WithMessage(string message, int applicantId)
        {
            ViewBag.Message = message;
            ViewBag.applicantId = applicantId;
            return View("Index");
        }

        public ActionResult GetSheffieldCourses(int id)
        {
            IList<CourseBEAN> courses = service.GetSheffieldCourses();
            ViewBag.applicantId = id;
            ViewBag.ToManyApplications = appService.GetApplications(id).Count >= 5;
            return View(courses);
        }

        public ActionResult GetSheffieldHalamCourses(int id)
        {
            IList<CourseBEAN> courses = service.GetSheffieldHallamCourses();
            ViewBag.applicantId = id;
            ViewBag.ToManyApplications = appService.GetApplications(id).Count >= 5;
            return View(courses);
        }

    }
}