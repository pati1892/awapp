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
        private readonly naasi.IUniversityService uniService = null;

        #endregion Fields

        #region Constructors

        public ApplicationService()
        {
            appService = new naass.ApplicationService();
            uniService = new naass.UniversityService();
        }

        #endregion Constructors

        #region Methods

        [WebMethod(Description = "Get all applications of an university")]
        public List<ApplicationBEAN> GetApplications(string universityName)
        {
            var uni = uniService.GetUniversity(universityName);
            if (uni == null)
            {
                return null;
            }
            return appService.GetApplications(universityName).ToList();
        }

        [WebMethod(Description = "Change the state of an application. (Allowed values are 'C'=Conditional, U='Unconditional', R='Reject')")]
        public bool SetApplicationOfferState(int applicationId, string universityName, string offerState)
        {
            if (string.IsNullOrEmpty(offerState) || offerState.Length != 1)
            {
                return false;
            }
            if (offerState.Equals("U", StringComparison.OrdinalIgnoreCase))
            {
                return this.SetUnconditionalApplication(applicationId, universityName);
            }
            else if (offerState.Equals("C", StringComparison.OrdinalIgnoreCase))
            {
                return this.SetConditionalApplication(applicationId, universityName);
            }
            else if (offerState.Equals("R", StringComparison.OrdinalIgnoreCase))
            {
                return this.SetRejectApplication(applicationId, universityName);
            }
            return false;
        }

        [WebMethod(Description = "Updates the state of an application to 'conditonal'")]
        public bool SetConditionalApplication(int applicationId, string universityName)
        {
            Data.Application application;
            bool validInput = CheckPreConditions(applicationId, universityName, out application);
            if (!validInput)
            {
                return validInput;
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
        public bool SetRejectApplication(int applicationId, string universityName)
        {
            Data.Application application;
            bool validInput = CheckPreConditions(applicationId, universityName, out application);
            if (!validInput)
            {
                return validInput;
            }
            var currentValue = application.UniversityOffer;
            var newValue = ((char)ApplicationState.Reject).ToString();
            if (currentValue != newValue)
            {
                if (!(currentValue == ((char)ApplicationState.Pending).ToString() || currentValue == ((char)ApplicationState.Conditional).ToString()))
                {
                    return false;
                }
            }
            application.UniversityOffer = newValue;
            appService.EditApplicationState(applicationId, ApplicationState.Reject);
            return true;
        }

        [WebMethod(Description = "Updates the state of an application to 'unconditional'")]
        public bool SetUnconditionalApplication(int applicationId, string universityName)
        {
            Data.Application application;
            bool validInput = CheckPreConditions(applicationId, universityName, out application);
            if (!validInput)
            {
                return validInput;
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
        private bool CheckPreConditions(int applicationId, string universityName, out Data.Application application)
        {
            application = appService.GetApplication(applicationId);
            var uni = uniService.GetUniversity(universityName);
            if (uni == null)
            {
                return false;
            }
            if (application == null)
            {
                return false;
            }
            if (appService.IsEnrolled(application.ApplicantId))
            {
                return false;
            }
            if (application.UniversityId != uni.UniversityId)
            {
                return false;
            }
            if (application.Firm.HasValue)
            {
                return false;
            }
            return true;
        }

        #endregion Methods

    }
}
