using NAA.CourseService.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.CourseService.Mapper
{
    internal class CourseMapper
    {
        #region Fields

        private static CourseMapper instance = null;

        #endregion Fields

        #region Constructors

        private CourseMapper()
        {

        }

        #endregion Constructors

        #region Methods

        public static CourseMapper GetInstance()
        {
            if (instance == null)
            {
                instance = new CourseMapper();
            }
            return instance;
        }

        public CourseBEAN Map(Sheffield.Course course)
        {
            var result = new CourseBEAN();
            
            return result;
        }
        public CourseBEAN Map(SheffieldHallam.SHUCourse course)
        {
            var result = new CourseBEAN();

            return result;
        }

        #endregion Methods

    }
}
