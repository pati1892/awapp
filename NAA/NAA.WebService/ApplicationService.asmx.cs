using NAA.Data.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using naass = NAA.Service.Service;
using naasi = NAA.Service.IService;
using NAA.Data.Enum;

namespace NAA.WebService
{
    /// <summary>
    /// Summary description for ApplicationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ApplicationService : System.Web.Services.WebService
    {
        private readonly naasi.IApplicationService appService = null;

        public ApplicationService()
        {
            appService = new naass.ApplicationService();
        }

        #region Methods

        [WebMethod(Description ="Get all Applications of an university")]
        public List<ApplicationBEAN> GetApplications(string universityName)
        {
            return appService.GetApplications(universityName).ToList();
        }

        [WebMethod(Description ="Updates the state of an application to 'conditonal'")]
        public bool SetConditionalApplication(int applicationId)
        {
            var application = appService.GetApplication(applicationId);
            var currentValue = application.UniversityOffer;
            var newValue = ((char)ApplicationState.Conditional).ToString();
            if (currentValue != newValue)
            {
                if (application.Firm.HasValue && application.Firm.Value || currentValue == ((char)ApplicationState.Reject).ToString() || currentValue == ((char)ApplicationState.Unconditional).ToString())
                {
                    return false;
                }
            }
            application.UniversityOffer = newValue;
            appService.EditApplication(application);
            return true;
        }

        [WebMethod(Description = "Updates the state of an application to 'reject'")]
        public bool SetRejectApplication(int applicationId)
        {
            var application = appService.GetApplication(applicationId);
            var currentValue = application.UniversityOffer;
            var newValue = ((char)ApplicationState.Reject).ToString();
            if (currentValue != newValue)
            {
                if (application.Firm.HasValue && application.Firm.Value || currentValue != ((char)ApplicationState.Pending).ToString())
                {
                    return false;
                }
            }
            application.UniversityOffer = newValue;
            appService.EditApplication(application);
            return true;
        }


        [WebMethod(Description = "Updates the state of an application to 'unconditional'")]
        public bool SetUnconditionalApplication(int applicationId)
        {
            var application = appService.GetApplication(applicationId);
            var currentValue = application.UniversityOffer;
            var newValue = ((char)ApplicationState.Reject).ToString();
            if (currentValue != newValue)
            {
                if (application.Firm.HasValue && application.Firm.Value || currentValue == ((char)ApplicationState.Reject).ToString())
                {
                    return false;
                }
            }
            application.UniversityOffer = newValue;
            appService.EditApplication(application);
            return true;
        }

        #endregion Methods

    }
}
