using FrontEnd_Student.Models;
using FrontEnd_Student.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd_Student.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly StudentService _studentService;

        public StudentController(ILogger<StudentController> logger, StudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }


        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return View(students);
        }

        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentService.CreateStudentAsync(student);
                return Json(new { success = true });
            }
            return PartialView(student);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return PartialView(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _studentService.UpdateStudentAsync(id, student);
                return Json(new { success = true });
            }
            return PartialView(student);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return PartialView(student);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return PartialView(student);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _studentService.DeleteStudentAsync(id);
            return Json(new { success = true });
        }
    } 

}


