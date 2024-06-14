using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("studentAPI")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            var students = studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("GetStudentById/{id:Guid}")]
        public IActionResult GetStudentById([FromRoute] Guid id)
        {
            var student = studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost("InsertNewStudent")]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdStudent = studentService.CreateStudent(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Id }, createdStudent);
        }

        [HttpDelete("DeleteStudentById/{id:Guid}")]
        public IActionResult DeleteStudentById([FromRoute] Guid id)
        {
            var student = studentService.DeleteStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut("UpdateStudent/{id:Guid}")]
        public IActionResult UpdateStudent([FromRoute] Guid id, [FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedStudent = studentService.UpdateStudent(id, student);
            if (updatedStudent == null)
            {
                return NotFound();
            }
            return Ok(updatedStudent);
        }
    }
}
