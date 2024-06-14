using System.ComponentModel.DataAnnotations;

namespace FrontEnd_Student.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
