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

        CourseBEAN GetSheffieldCourse(int courseId);

        IList<CourseBEAN> GetSheffieldCourses();
        CourseBEAN GetSheffieldHallamCourse(int courseId);

        IList<CourseBEAN> GetSheffieldHallamCourses();

        #endregion Methods
    }
}
