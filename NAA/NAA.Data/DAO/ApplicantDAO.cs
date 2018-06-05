using NAA.Data.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.DAO
{
    public class ApplicantDAO : IApplicantDAO
    {

        private NaaEntities context; 

        public ApplicantDAO()
        {
            this.context = new NaaEntities();
        }

        public void AddApplicant(Applicant applicant)
        {
            context.Applicant.Add(applicant);
        }

        public List<Applicant> GetAllApplicants()
        {
            IQueryable<Applicant> applicants;
            applicants = from applicant
                         in context.Applicant
                         select applicant;
            return applicants.ToList<Applicant>();
        }
    }
}
