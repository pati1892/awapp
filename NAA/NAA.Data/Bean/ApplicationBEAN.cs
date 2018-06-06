using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.Bean
{
    public class ApplicationBEAN
    {
        public int ApplicantId { get; set; }
        public string ApplicantName { get; set; }
        public string CourseName { get; set; }
        public Nullable<bool> Firm { get; set; }
        public int Id { get; set; }
        public string PersonalStatement { get; set; }
        public string TeacherContactDetails { get; set; }
        public string TeacherReference { get; set; }
        public string University { get; set; }
        public string UniversityOffer { get; set; }
    }
}
