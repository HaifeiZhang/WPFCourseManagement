using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCourseManagement.Model
{
    public class CourseModel
    {
        public string CourseName { get; set; }
        public string Cover { get; set; }
        public string course { get; set; } = "公开课";
        public string Url { get; set; }
        public string Description { get; set; }

        public List<string> techers { get; set; }

        public bool IsShowSkeleton { get; set; }
    }
}
