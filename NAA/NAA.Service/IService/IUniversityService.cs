using NAA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Service.IService
{
    public interface IUniversityService
    {

        #region Methods

        IList<University> GetUniversites();

        University GetUniversity(string name);
        University GetUniversity(int id);

        #endregion Methods

    }
}
