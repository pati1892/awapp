﻿using NAA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Service.IService
{
    public interface IApplicantService
    {

        #region Methods

        void AddApplicant(Applicant applicant);

        void DeleteApplicant(int id);

        void EditApplicant(Applicant applicant);
        List<Applicant> GetAllApplicants();

        Applicant GetApplicant(int id);

        #endregion Methods

    }
}
