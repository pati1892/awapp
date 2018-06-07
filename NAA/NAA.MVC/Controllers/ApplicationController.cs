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
            if (appService.IsDuplicate(course, applicantId))
            {
                return RedirectToAction("WithMessage", "Course", new { message = $"You already applied to '{course.Name}'.", applicantId = applicantId });
            }
            return View();
        }

        [HttpPost]
        public ActionResult ApplyHalam(Application application, int courseId, int applicantId)
        {
            CourseBEAN course = service.GetSheffieldHallamCourses().First(x => x.Id == courseId);
            ViewBag.Course = course;
            ViewBag.University = uniService.GetUniversity(course.University);
            //validation
            if (string.IsNullOrEmpty(application.PersonalStatement))
            {
                ModelState.AddModelError("PersonalStatement", "Personal statement is required");
            }
            else if (string.IsNullOrEmpty(application.TeacherContactDetails))
            {
                ModelState.AddModelError("TeacherContactDetails", "Teacher contact details are required");
            }
            if (ModelState.IsValid)
            {
                appService.AddApplication(application, course, applicantId);
                return RedirectToAction("GetAllApplications", "Application", new { id = applicantId });
            }
            return View();
        }

        public ActionResult ApplySheffield(int courseId, int applicantId)
        {
            CourseBEAN course = service.GetSheffieldCourses().First(x => x.Id == courseId);
            ViewBag.Course = course;
            ViewBag.University = uniService.GetUniversity(course.University);
            if (appService.IsDuplicate(course, applicantId))
            {
                return RedirectToAction("WithMessage", "Course", new { message = $"You already applied to '{course.Name}'.", applicantId = applicantId });
            }
            return View();
        }

        [HttpPost]
        public ActionResult ApplySheffield(Application application, int courseId, int applicantId)
        {
            CourseBEAN course = service.GetSheffieldCourses().First(x => x.Id == courseId);
            ViewBag.Course = course;
            ViewBag.University = uniService.GetUniversity(course.University);
            //validation
            if (string.IsNullOrEmpty(application.PersonalStatement))
            {
                ModelState.AddModelError("PersonalStatement", "Personal statement is required");
            }
            else if (string.IsNullOrEmpty(application.TeacherContactDetails))
            {
                ModelState.AddModelError("TeacherContactDetails", "Teacher contact details are required");
            }
            if (ModelState.IsValid)
            {
                appService.AddApplication(application, course, applicantId);
                return RedirectToAction("GetAllApplications", "Application", new { id = applicantId });
            }
            return View();
        }

        public ActionResult DeleteApplication(int id, int applicantId)
        {
            if (!appService.DeletableOrEditable(id, applicantId))
            {
                return RedirectToAction("NotAllowMethod", "Home");
            }
            Application application = appService.GetApplication(id);
            ViewBag.applicantId = applicantId;
            return View(application);
        }

        [HttpPost]
        public ActionResult DeleteApplication(Application application, int applicantId)
        {
            if (!appService.DeletableOrEditable(application.Id, applicantId))
            {
                return RedirectToAction("NotAllowMethod", "Home");
            }
            appService.DeleteApplication(application.Id);
            return RedirectToAction("GetAllApplications", "Application", new { id = applicantId });
        }

        public ActionResult EditApplication(int id, int applicantId)
        {
            if (!appService.DeletableOrEditable(id, applicantId))
            {
                return RedirectToAction("NotAllowMethod", "Home");
            }
            Application application = appService.GetApplication(id);
            ViewBag.applicantId = applicantId;
            return View(application);
        }

        [HttpPost]
        public ActionResult EditApplication(Application application, int applicantId)
        {
            if (!appService.DeletableOrEditable(application.Id, applicantId))
            {
                return RedirectToAction("NotAllowMethod", "Home");
            }
            //validation
            if (string.IsNullOrEmpty(application.PersonalStatement))
            {
                ModelState.AddModelError("PersonalStatement", "Personal statement is required");
            }
            else if (string.IsNullOrEmpty(application.TeacherContactDetails))
            {
                ModelState.AddModelError("TeacherContactDetails", "Teacher contact details are required");
            }
            if (ModelState.IsValid)
            {
                appService.EditApplication(application);
                return RedirectToAction("GetAllApplications", "Application", new { id = applicantId });
            }
            return View();
        }

        public ActionResult EnrollApplication(int id, int applicantId)
        {
            appService.EditFirm(id, true);
            return RedirectToAction("GetAllApplications", "Application", new { id = applicantId });
        }

        // GET: Application
        public ActionResult GetAllApplications(int id)
        {
            IList<ApplicationBEAN> applications = appService.GetApplications(id);
            ViewBag.applicantId = id;
            ViewBag.IsEnrolled = appService.IsEnrolled(id);
            return View(applications);
        }
        public ActionResult RejectApplication(int id, int applicantId)
        {
            appService.EditFirm(id, false);
            return RedirectToAction("GetAllApplications", "Application", new { id = applicantId });
        }

        #endregion Methods

    }
}