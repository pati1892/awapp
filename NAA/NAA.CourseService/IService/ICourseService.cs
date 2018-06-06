using NAA.CourseService.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.CourseService.IService
{
    public interface ICourseService
    {
        #region Methods

        IList<CourseBEAN> GetSheffieldCourses();
        IList<CourseBEAN> GetSheffieldHallamCourses();

        #endregion Methods
    }
}
