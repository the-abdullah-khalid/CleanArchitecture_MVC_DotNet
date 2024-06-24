using Domain;

namespace Application
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        Student? GetStudent(Guid id);

        Student CreateStudent(Student student);

        Student? DeleteStudent(Guid id);

        Student? UpdateStudent(Guid id, Student student);


    }
}
