using NAA.Data.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.DAO
{
    public class UniversityDAO : IUniversityDAO
            {


        private NaaEntities context;

        public UniversityDAO()
        {
            this.context = new NaaEntities();
        }

        #region Methods

        public IList<University> GetUniversites()
        {
            IQueryable<University> unis;
            unis = from uni
                   in context.University
                   select uni;

            return unis.ToList();
        }

        public University GetUniversity(string name)
        {
            return null;
        }

        public University GetUniversity(int id)
        {
            return null;
        }

        #endregion Methods
    }
}
