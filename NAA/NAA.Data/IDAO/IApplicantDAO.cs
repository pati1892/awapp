using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.IDAO
{
    public interface IApplicantDAO
    {

        void AddApplicant(Applicant applicant);

        List<Applicant> GetAllApplicants();


    }
}
