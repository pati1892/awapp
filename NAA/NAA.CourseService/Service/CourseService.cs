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
        private readonly Sheffield.SheffieldWebService sheffieldProxy = null;
        private readonly SheffieldHallam.SHUWebService sheffieldHalamProxy = null;
        public CourseService()
        {
            sheffieldProxy = new Sheffield.SheffieldWebService();
            sheffieldHalamProxy = new SheffieldHallam.SHUWebService();
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
    }
}
