using NAA.Data.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

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

        #region Methods

        [WebMethod]
        public List<ApplicationBEAN> GetApplications(string universityName)
        {
            return null;
        }

        [WebMethod]
        public bool SetConditionalApplication(int applicationId)
        {
            return true;
        }

        [WebMethod]
        public bool SetRejectApplication(int applicationId)
        {
            return true;
        }
        [WebMethod]
        public bool SetUnconditionalApplication(int applicationId)
        {
            return true;
        }

        #endregion Methods

    }
}
