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

        private readonly IApplicantDAO dao;

        #endregion Fields

        #region Constructors

        public ApplicantService()
        {
            dao = new ApplicantDAO();
        }

        #endregion Constructors

        #region Methods

        public void AddApplicant(Applicant applicant)
        {
            dao.AddApplicant(applicant);
        }

        public void DeleteApplicant(int id)
        {
            dao.DeleteApplicant(id);
        }

        public void EditApplicant(Applicant applicant)
        {
            dao.EditApplicant(applicant);
        }

        public List<Applicant> GetAllApplicants()
        {
            return dao.GetAllApplicants();
        }

        public Applicant GetApplicant(int id)
        {
            return dao.GetApplicant(id);
        }

        #endregion Methods
    }
}
