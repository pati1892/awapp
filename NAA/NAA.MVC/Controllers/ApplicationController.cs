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

        IApplicationService service;

        public ApplicationController()
        {
            service = new ApplicationService();
        }

        // GET: Application
        public ActionResult Index()
        {
            return View();
        }
    }
}