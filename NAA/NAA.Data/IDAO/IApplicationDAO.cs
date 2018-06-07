using NAA.Data.Bean;
using NAA.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.IDAO
{
    public interface IApplicationDAO
    {

        #region Methods

        void AddApplication(Application application);
        void DeleteApplication(int id);
        void EditApplication(Application application);

        void EditApplicationState(int applicationId, ApplicationState state);
        void EditFirm(int applicationId, bool enroll);

        Application GetApplication(int id);

        IList<ApplicationBEAN> GetApplications(int applicantId);
        IList<ApplicationBEAN> GetApplications(string universityName);

        #endregion Methods

    }
}
