using NAA.CourseService.Bean;
using NAA.CourseService.IService;
using NAA.CourseService.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.CourseService.Service
{
    public class CourseService : ICourseService
    {

        #region Fields

        private readonly SheffieldHallam.SHUWebService sheffieldHalamProxy = null;
        private readonly Sheffield.SheffieldWebService sheffieldProxy = null;

        #endregion Fields

        #region Constructors

        public CourseService()
        {
            sheffieldProxy = new Sheffield.SheffieldWebService();
            sheffieldHalamProxy = new SheffieldHallam.SHUWebService();
        }

        #endregion Constructors

        #region Methods

        public CourseBEAN GetSheffieldCourse(int courseId)
        {
            return this.GetSheffieldCourses().FirstOrDefault(x => x.Id == courseId);
        }

        public IList<CourseBEAN> GetSheffieldCourses()
        {
            var courseList = sheffieldProxy.SheffCourses();
            IList<CourseBEAN> result = new List<CourseBEAN>();
            if (courseList != null)
            {
                foreach (Sheffield.Course course in courseList)
                {
                    result.Add(CourseMapper.GetInstance().Map(course));
                }
            }
            return result;
        }

        public CourseBEAN GetSheffieldHallamCourse(int courseId)
        {
            return this.GetSheffieldHallamCourses().FirstOrDefault(x => x.Id == courseId);
        }

        public IList<CourseBEAN> GetSheffieldHallamCourses()
        {
            var courseList = sheffieldHalamProxy.SHUCourses();
            IList<CourseBEAN> result = new List<CourseBEAN>();
            if (courseList != null)
            {
                foreach (SheffieldHallam.SHUCourse course in courseList)
                {
                    result.Add(CourseMapper.GetInstance().Map(course));
                }
            }
            return result;
        }

        #endregion Methods

    }
}
