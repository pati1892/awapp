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

        #region Fields

        private readonly IApplicationDAO applicationDAO;
        private readonly IUniversityService universityService;

        #endregion Fields

        #region Constructors

        public ApplicationService()
        {
            universityService = new UniversityService();
            applicationDAO = new ApplicationDAO();
        }

        #endregion Constructors

        #region Methods

        public void AddApplication(Application application, CourseBEAN course, int applicantId)
        {
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

        public void EditApplicationState(int applicationId, ApplicationState state)
        {
            applicationDAO.EditApplicationState(applicationId, state);
        }

        public void EditFirm(int applicationId, bool enroll)
        {
            if (enroll)
            {
                var app = this.GetApplication(applicationId);
                var apps = this.GetApplications(app.ApplicantId);
                foreach (ApplicationBEAN item in apps)
                {
                    if (item.Id != applicationId)
                    {
                        applicationDAO.EditFirm(item.Id, false);
                    }
                }
            }
            applicationDAO.EditFirm(applicationId, enroll);
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

        public bool IsDuplicate(CourseBEAN course, int applicantId)
        {
            //check if duplicate course
            return (this.GetApplications(applicantId).Any(x => x.University == course.University && x.ApplicantId == applicantId && x.CourseName == course.Name));
        }

        #endregion Methods
    }
}
