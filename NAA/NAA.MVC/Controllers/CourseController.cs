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
            ViewBag.ShowInfo = appService.IsEnrolled(id);
            ViewBag.InfoMessage = "You already enrolled.";
            if (!ViewBag.ShowInfo)
            {
                ViewBag.ShowInfo = appService.GetApplications(id).Count >= 5;
                ViewBag.InfoMessage = "You are already applied to 5 courses.";
            }
            return View();
        }
        public ActionResult WithMessage(string message, int applicantId)
        {
            ViewBag.Message = message;
            ViewBag.applicantId = applicantId;
            ViewBag.ShowInfo = false;
            return View("Index");
        }

        public ActionResult GetSheffieldCourses(int id)
        {
            IList<CourseBEAN> courses = service.GetSheffieldCourses();
            ViewBag.applicantId = id;
            ViewBag.CanApply = !appService.IsEnrolled(id) && appService.GetApplications(id).Count < 5;
            return View(courses);
        }

        public ActionResult GetSheffieldHalamCourses(int id)
        {
            IList<CourseBEAN> courses = service.GetSheffieldHallamCourses();
            ViewBag.applicantId = id;
            ViewBag.CanApply = !appService.IsEnrolled(id) && appService.GetApplications(id).Count < 5;
            return View(courses);
        }

    }
}