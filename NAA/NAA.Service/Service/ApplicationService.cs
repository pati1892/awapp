using NAA.CourseService.Bean;
using NAA.Data;
using NAA.Data.Bean;
using NAA.Data.DAO;
using NAA.Data.Enum;
using NAA.Data.IDAO;
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
        private readonly IUniversityService universityService;
        private readonly IApplicationDAO applicationDAO;  

        public ApplicationService()
        {
            universityService = new UniversityService();
            applicationDAO = new ApplicationDAO();
        }

        public void AddApplication(CourseBEAN course, int applicantId)
        {
            Application application = new Application();
            application.ApplicantId = applicantId;
            application.CourseName = course.Name;
            application.UniversityId = universityService.GetUniversity(course.University).UniversityId;
            application.UniversityOffer = ((char)ApplicationState.Pending).ToString();
            applicationDAO.AddApplication(application);
        }

        public void DeleteApplication(int id)
        {
            applicationDAO.DeleteApplication(id);
        }

        public void EditApplication(Application application)
        {
            applicationDAO.EditApplication(application);
        }

        public Application GetApplication(int id)
        {
            return applicationDAO.GetApplication(id);
        }

        public IList<ApplicationBEAN> GetApplications(int applicantId)
        {
            return applicationDAO.GetApplications(applicantId);
        }

        public IList<ApplicationBEAN> GetApplications(string universityName)
        {
            return applicationDAO.GetApplications(universityName);
        }

        #endregion Methods
    }
}
