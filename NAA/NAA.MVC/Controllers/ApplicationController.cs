using NAA.CourseService.Bean;
using NAA.CourseService.IService;
using NAA.Data;
using NAA.Data.Bean;
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
    public class ApplicationController : Controller
    {

        #region Fields

        IApplicationService appService;
        ICourseService service;
        IUniversityService uniService;

        #endregion Fields

        #region Constructors

        public ApplicationController()
        {
            service = new CourseService.Service.CourseService();
            appService = new ApplicationService();
            uniService = new UniversityService();
        }

        #endregion Constructors

        #region Methods

        public ActionResult ApplyHalam(int courseId, int applicantId)
        {
            CourseBEAN course = service.GetSheffieldHallamCourses().First(x => x.Id == courseId);
            ViewBag.Course = course;
            ViewBag.University = uniService.GetUniversity(course.University);
            return View();
        }

        [HttpPost]
        public ActionResult ApplyHalam(Application application, int courseId, int applicantId)
        {
            CourseBEAN course = service.GetSheffieldHallamCourses().First(x => x.Id == courseId);
            appService.AddApplication(application, course, applicantId);
            return RedirectToAction("GetAllApplications", "Application", new { id = applicantId });
        }

        public ActionResult ApplySheffield(int courseId, int applicantId)
        {
            CourseBEAN course = service.GetSheffieldCourses().First(x => x.Id == courseId);
            ViewBag.Course = course;
            ViewBag.University = uniService.GetUniversity(course.University);
            return View();
        }

        [HttpPost]
        public ActionResult ApplySheffield(Application application, int courseId, int applicantId)
        {
            CourseBEAN course = service.GetSheffieldCourses().First(x => x.Id == courseId);
            appService.AddApplication(application, course, applicantId);
            return RedirectToAction("GetAllApplications", "Application", new { id = applicantId });
        }

        // GET: Application
        public ActionResult GetAllApplications(int id)
        {
            IList<ApplicationBEAN> applications = appService.GetApplications(id);
            ViewBag.applicantId = id;

            return View(applications);
        }

        #endregion Methods
    }
}