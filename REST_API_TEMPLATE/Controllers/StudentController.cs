using Microsoft.AspNetCore.Mvc;
using REST_API_TEMPLATE.Models;
using REST_API_TEMPLATE.Sevices;

namespace REST_API_TEMPLATE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILibraryService _schoolService;

        public StudentController(ILibraryService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _schoolService.GetStudentsAsync();

            if (students == null || students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _schoolService.GetStudentAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }


        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            var dbStudent = await _schoolService.AddStudentAsync(student);

            if (dbStudent == null)
            {
                return StatusCode(500, $"{student.Name} could not be added.");
            }

            return CreatedAtAction("GetStudent", new { id = student.StudentID }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.StudentID)
            {
                return BadRequest();
            }

            Student dbStudent = await _schoolService.UpdateStudentAsync(student);

            if (dbStudent == null)
            {
                return StatusCode(500, $"{student.Name} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _schoolService.GetStudentAsync(id);
            (bool status, string message) = await _schoolService.DeleteStudentAsync(student);

            if (status == false)
            {
                return StatusCode(500, message);
            }

            return StatusCode(200, student);
        }
    }
}
