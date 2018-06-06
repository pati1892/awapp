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
    public class UniversityService : IUniversityService
    { 
        private readonly IUniversityDAO dao;
        public UniversityService()
        {
            dao = new UniversityDAO();
        }

        #region Methods

        public IList<University> GetUniversites()
        {
            return dao.GetUniversites();
        }

        public University GetUniversity(string name)
        {
            return dao.GetUniversity(name);
        }

        public University GetUniversity(int id)
        {
            return dao.GetUniversity(id);
        }

        #endregion Methods
    }
}
