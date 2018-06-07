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

        #region Fields

        private readonly naasi.IApplicationService appService = null;

        #endregion Fields

        #region Constructors

        public ApplicationService()
        {
            appService = new naass.ApplicationService();
        }

        #endregion Constructors

        #region Methods

        [WebMethod(Description = "Get all Applications of an university")]
        public List<ApplicationBEAN> GetApplications(string universityName)
        {
            return appService.GetApplications(universityName).ToList();
        }

        [WebMethod(Description = "Updates the state of an application to 'conditonal'")]
        public bool SetConditionalApplication(int applicationId)
        {
            var application = appService.GetApplication(applicationId);
            if (application == null)
            {
                return false;
            }
            if (appService.IsEnrolled(application.ApplicantId))
            {
                return false;
            }
            var currentValue = application.UniversityOffer;
            var newValue = ((char)ApplicationState.Conditional).ToString();
            if (currentValue != newValue)
            {
                if (!(currentValue == ((char)ApplicationState.Pending).ToString()))
                {
                    return false;
                }
            }
            application.UniversityOffer = newValue;
            appService.EditApplicationState(applicationId, ApplicationState.Conditional);
            return true;
        }

        [WebMethod(Description = "Updates the state of an application to 'reject'")]
        public bool SetRejectApplication(int applicationId)
        {
            var application = appService.GetApplication(applicationId);
            if (application == null)
            {
                return false;
            }
            if (appService.IsEnrolled(application.ApplicantId))
            {
                return false;
            }
            var currentValue = application.UniversityOffer;
            var newValue = ((char)ApplicationState.Reject).ToString();
            if (currentValue != newValue)
            {
                if (!(currentValue == ((char)ApplicationState.Pending).ToString()))
                {
                    return false;
                }
            }
            application.UniversityOffer = newValue;
            appService.EditApplicationState(applicationId, ApplicationState.Reject);
            return true;
        }


        [WebMethod(Description = "Updates the state of an application to 'unconditional'")]
        public bool SetUnconditionalApplication(int applicationId)
        {
            var application = appService.GetApplication(applicationId);
            if (application == null)
            {
                return false;
            }
            if (appService.IsEnrolled(application.ApplicantId))
            {
                return false;
            }
            var currentValue = application.UniversityOffer;
            var newValue = ((char)ApplicationState.Unconditional).ToString();
            if (currentValue != newValue)
            {
                if (!(currentValue == ((char)ApplicationState.Pending).ToString() || currentValue == ((char)ApplicationState.Conditional).ToString()))
                {
                    return false;
                }
            }
            appService.EditApplicationState(applicationId, ApplicationState.Unconditional);
            return true;
        }

        #endregion Methods

    }
}
