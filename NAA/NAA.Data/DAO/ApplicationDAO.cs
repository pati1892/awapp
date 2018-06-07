using NAA.Data.Bean;
using NAA.Data.Enum;
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

        private NaaEntities context;

        public ApplicationDAO()
        {
            this.context = new NaaEntities();
        }

        #region Methods

        public void AddApplication(Application application)
        {
            context.Application.Add(application);
            context.SaveChanges();
        }

        public void DeleteApplication(int id)
        {
            context.Application.Remove(this.GetApplication(id));
            context.SaveChanges();
        }

        public void EditApplication(Application application)
        {
            Application dbApplication = GetApplication(application.Id);
            dbApplication.PersonalStatement = application.PersonalStatement;
            dbApplication.TeacherContactDetails = application.TeacherContactDetails;
            dbApplication.TeacherReference = application.TeacherReference;
            context.SaveChanges();
        }
        public void EditApplicationState(int applicationId, ApplicationState state)
        {
            Application dbApplication = GetApplication(applicationId);
            dbApplication.UniversityOffer = ((char)state).ToString();
            context.SaveChanges();
        }

        public void EditFirm(int applicationId, bool enroll)
        {
            Application dbApplication = GetApplication(applicationId);
            dbApplication.Firm = enroll;
            context.SaveChanges();
        }

        public Application GetApplication(int id)
        {
            return context.Application.First(r => r.Id == id);
        }

        public IList<ApplicationBEAN> GetApplications(int applicantId)
        {

            IUniversityDAO uniDao = new UniversityDAO();
            IApplicantDAO appDao = new ApplicantDAO();
            var applicantName = appDao.GetApplicant(applicantId).ApplicantName;
            return context
                .Application
                .Where(r => r.ApplicantId == applicantId)
                .ToList()
                .Select(r => new ApplicationBEAN()
                {
                    Id = r.Id
                    ,
                    ApplicantId = r.ApplicantId
                    ,
                    ApplicantName = applicantName
                    ,
                    CourseName = r.CourseName
                    ,
                    Firm = r.Firm
                    ,
                    PersonalStatement = r.PersonalStatement
                    ,
                    TeacherContactDetails = r.TeacherContactDetails
                    ,
                    TeacherReference = r.TeacherReference
                    ,
                    University = uniDao.GetUniversity(r.UniversityId).UniversityName
                    ,
                    UniversityOffer = r.UniversityOffer
                })
                .OrderBy(x => x.University)
                .ThenBy(x => x.CourseName)
                .ToList();


        }

        public IList<ApplicationBEAN> GetApplications(string universityName)
        {

            int uniId = new UniversityDAO().GetUniversity(universityName).UniversityId;
            IApplicantDAO appDao = new ApplicantDAO();

            return context
                .Application
                .Where(r => r.UniversityId == uniId)
                .ToList()
                .Select(r => new ApplicationBEAN()
                {
                    Id = r.Id
                    ,
                    ApplicantId = r.ApplicantId
                    ,
                    ApplicantName = appDao.GetApplicant(r.ApplicantId).ApplicantName
                    ,
                    CourseName = r.CourseName
                    ,
                    Firm = r.Firm
                    ,
                    PersonalStatement = r.PersonalStatement
                    ,
                    TeacherContactDetails = r.TeacherContactDetails
                    ,
                    TeacherReference = r.TeacherReference
                    ,
                    University = universityName
                    ,
                    UniversityOffer = r.UniversityOffer
                })
                .ToList();

        }

        #endregion Methods
    }
}
