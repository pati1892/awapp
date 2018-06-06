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

        private static readonly string SHEFFIELDHALAMNAME = "Sheffield Hallam";
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
            result.Condition = course.EntryReq;
            result.Degree = course.Qulaification;
            result.Description = course.Description;
            result.Id = course.Id;
            result.Name = course.Name;
            result.Nss = course.NSS.ToString();
            result.Tarif = course.Tarif.ToString();
            result.University = course.University;
            return result;
        }
        public CourseBEAN Map(SheffieldHallam.SHUCourse course)
        {
            var result = new CourseBEAN();
            result.Condition = course.CRequirements;
            result.Degree = course.CDegree;
            result.Description = course.CDescription;
            result.Id = course.CourseId;
            result.Name = course.CName;
            result.Nss = course.CNSS;
            result.Tarif = course.CTarif;
            result.University = SHEFFIELDHALAMNAME;
            return result;
        }

        #endregion Methods

    }
}
