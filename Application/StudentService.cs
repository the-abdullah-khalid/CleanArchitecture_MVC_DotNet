using Domain;

namespace Application
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public Student CreateStudent(Student student)
        {
            var _student = studentRepository.CreateStudent(student);
            return _student;
        }

        public Student DeleteStudent(Guid id)
        {
            var student = studentRepository.DeleteStudent(id);
            return student;
        }

        public List<Student> GetAllStudents()
        {
            var students=studentRepository.GetAllStudents();
            return students;
        }

        public Student GetStudent(Guid id)
        {
            var student=studentRepository.GetStudent(id);
            return student;
        }

        public Student UpdateStudent(Guid id,Student student)
        {
            var _student=studentRepository.UpdateStudent(id,student);
            return _student;
        }
    }
}
