using System.ComponentModel.DataAnnotations;

namespace REST_API_TEMPLATE.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string? Name { get; set; }


        public List<StudentSCourses>? StudentCourses { get; set; }
    }
}
