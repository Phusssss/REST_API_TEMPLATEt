using System.Text.Json.Serialization;

namespace REST_API_TEMPLATE.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public List<StudentSCourses>? StudentCourses { get; set; }
    }
}
