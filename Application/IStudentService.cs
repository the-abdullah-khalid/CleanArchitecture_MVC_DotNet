using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student GetStudent(Guid id);

        Student CreateStudent(Student student);

        Student DeleteStudent(Guid id);

        Student UpdateStudent(Guid id, Student student);
    }
}
