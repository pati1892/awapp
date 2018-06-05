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

        private readonly IApplicantDAO dao;

        public ApplicantService()
        {
            dao = new ApplicantDAO();
        }

        public void addApplicant(Applicant applicant)
        {
            dao.AddApplicant(applicant);
        }

        public List<Applicant> GetAllApplicants()
        {
            return dao.GetAllApplicants();
        }
    }
}
