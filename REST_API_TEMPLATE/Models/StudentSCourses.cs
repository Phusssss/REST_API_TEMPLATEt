using System.Text.Json.Serialization;

namespace REST_API_TEMPLATE.Models
{
    public class StudentSCourses
    {
        public int CourseId { get; set; }
        public int StudentID { get; set; }
        [JsonIgnore]
        public Student? Students { get; set; }
        [JsonIgnore]
        public Course? Courses { get; set; }
    }
}
