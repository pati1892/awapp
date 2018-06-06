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
        IUniversityService uniService;

        public CourseController()
        {
            service = new CourseService.Service.CourseService();
            appService = new ApplicationService();
            uniService = new UniversityService();
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

        public ActionResult ApplySheffield(int courseId, int applicantId)
        {
            CourseBEAN course = service.GetSheffieldCourses().First(x => x.Id == courseId);
            ViewBag.CourseName = course.Name;
            ViewBag.UniversityId = uniService.GetUniversity(course.University).UniversityId;
            //ViewBag.ApplicantId = applicantId;

            //appService.AddApplication(course, applicantId);
            return View();
        }
        [HttpPost]
        public ActionResult ApplySheffield(Application application, int courseId, int applicantId)
        {
            
            CourseBEAN course = service.GetSheffieldCourses().First(x => x.Id == courseId);
            int UniversityId = uniService.GetUniversity(course.University).UniversityId;
            application.UniversityId = UniversityId;
            application.UniversityOffer = ((char)ApplicationState.Pending).ToString();
            application.CourseName = course.Name;
            //appService.AddApplication(course, applicantId);
            return View();
        }


        public ActionResult ApplyHalam(int courseId, int applicantId)
        {
            CourseBEAN course = service.GetSheffieldHallamCourses().First(x => x.Id == courseId);
            appService.AddApplication(course, applicantId);
            return View();
        }
    }
}