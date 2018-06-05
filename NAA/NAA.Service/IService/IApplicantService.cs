using NAA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Service.IService
{
    public interface IApplicantService
    {

        void addApplicant(Applicant applicant);

        List<Applicant> GetAllApplicants();

    }
}
