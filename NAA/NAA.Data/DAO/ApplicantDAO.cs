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
            context.SaveChanges();
        }

        public void DeleteApplicant(int id)
        {
            
            context.Applicant.Remove(this.GetApplicant(id));
            context.SaveChanges();
        }

        public void EditApplicant(Applicant applicant)
        {
            Applicant dbApplicant = GetApplicant(applicant.Id);
            dbApplicant.ApplicantAddress = applicant.ApplicantAddress;
            dbApplicant.ApplicantName = applicant.ApplicantName;
            dbApplicant.Email = applicant.Email;
            dbApplicant.Phone = applicant.Phone;

            context.SaveChanges();
        }

        public List<Applicant> GetAllApplicants()
        {
            IQueryable<Applicant> applicants;
            applicants = from applicant
                         in context.Applicant
                         select applicant;
            return applicants.ToList<Applicant>();
        }

        public Applicant GetApplicant(int id)
        {
            return  context.Applicant.First(r => r.Id == id);
            
        }
    }
}
