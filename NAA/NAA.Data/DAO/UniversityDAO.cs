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

        /// <summary>
        /// Initializes a new instance of the <see cref="UniversityDAO"/> class.
        /// </summary>
        public UniversityDAO()
        {
            this.context = new NaaEntities();
        }

        #region Methods

        /// <summary>
        /// Gets the universites.
        /// </summary>
        /// <returns></returns>
        public IList<University> GetUniversites()
        {
            IQueryable<University> unis;
            unis = from uni
                   in context.University
                   select uni;

            return unis.ToList();
        }

        /// <summary>
        /// Gets the university.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public University GetUniversity(string name)
        {
           return context.University.First(r => r.UniversityName == name); 
        }

        /// <summary>
        /// Gets the university.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public University GetUniversity(int id)
        {
            return context.University.First(r => r.UniversityId == id);
        }

        #endregion Methods
    }
}
