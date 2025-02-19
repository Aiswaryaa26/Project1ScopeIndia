using System.ComponentModel.DataAnnotations;

namespace Project1ScopeIndia.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }
       
        public string CourseName { get; set; }
        public string CourseDuration { get; set; }
        public int CourseAmount { get; set; }

    }
}
