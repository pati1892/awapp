using NAA.CourseService.Bean;
using NAA.Data;
using NAA.Data.Bean;
using NAA.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Service.Service
{
    public class ApplicationService : IApplicationService
    {
        #region Methods

        public void AddApplication(CourseBEAN course, int applicantId)
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
