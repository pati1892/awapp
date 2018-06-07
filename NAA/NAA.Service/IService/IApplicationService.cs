using NAA.CourseService.Bean;
using NAA.Data;
using NAA.Data.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Service.IService
{
    public interface IApplicationService
    {

        #region Methods

        void AddApplication(Application application, CourseBEAN course, int applicantId);

        void DeleteApplication(int id);

        void EditApplication(Application application);

        Application GetApplication(int id);

        IList<ApplicationBEAN> GetApplications(int applicantId);

        IList<ApplicationBEAN> GetApplications(string universityName);

        bool IsDuplicate(CourseBEAN course, int applicantId);

        #endregion Methods
    }
}
