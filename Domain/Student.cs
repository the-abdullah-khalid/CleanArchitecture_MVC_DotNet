using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } 
    }
}
