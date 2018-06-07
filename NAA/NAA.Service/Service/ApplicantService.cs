using NAA.Data;
using NAA.Data.DAO;
using NAA.Data.IDAO;
using NAA.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NAA.Service.Service
{
    public class ApplicantService : IApplicantService
    {

        #region Fields

        private readonly IApplicantDAO applicantDao;

        #endregion Fields

        #region Constructors

        public ApplicantService()
        {
            applicantDao = new ApplicantDAO();
        }

        #endregion Constructors

        #region Methods

        public void AddApplicant(Applicant applicant)
        {
            applicantDao.AddApplicant(applicant);
        }

        public void DeleteApplicant(int id)
        {
            applicantDao.DeleteApplicant(id);
        }

        public void EditApplicant(Applicant applicant)
        {
            applicantDao.EditApplicant(applicant);
        }

        public List<Applicant> GetAllApplicants()
        {
            return applicantDao.GetAllApplicants();
        }

        public Applicant GetApplicant(int id)
        {
            return applicantDao.GetApplicant(id);
        }


        #endregion Methods

    }
}
