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

        public CourseController()
        {
            service = new CourseService.Service.CourseService();
        }

        // GET: Course
        public ActionResult Index(int id)
        {
            ViewBag.applicantId = id;
            return View();
        }

        public ActionResult GetSheffieldCourses(int id)
        {
            IList<CourseBEAN> courses = service.GetSheffieldCourses();
            ViewBag.applicantId = id;
            return View(courses);
        }

        public ActionResult GetSheffieldHalamCourses(int id)
        {
            IList<CourseBEAN> courses = service.GetSheffieldHallamCourses();
            ViewBag.applicantId = id;
            return View(courses);
        }

    }
}