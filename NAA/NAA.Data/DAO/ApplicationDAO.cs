using NAA.Data.Bean;
using NAA.Data.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.DAO
{
    public class ApplicationDAO : IApplicationDAO
    {
        #region Methods

        public void AddApplication(Application application)
        {
        }

        public void DeleteApplication(int id)
        {
        }

        public void EditApplication(Application application)
        {
        }

        public Application GetApplication(int id)
        {
            return null;
        }

        public IList<ApplicationBEAN> GetApplications(int applicantId)
        {
            return null;
        }

        public IList<ApplicationBEAN> GetApplications(string universityName)
        {
            return null;
        }

        #endregion Methods
    }
}
