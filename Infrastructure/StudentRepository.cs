using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext studentDbContext;
        public StudentRepository(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        public Student CreateStudent(Student student)
        {
            studentDbContext.Students.Add(student);
            studentDbContext.SaveChanges();
            return student;
        }

        public Student? DeleteStudent(Guid id)
        {
            var student = studentDbContext.Students.FirstOrDefault(s => s.Id == id);
            if(student==null)
            {
                return null;
            }
            studentDbContext.Students.Remove(student);
            studentDbContext.SaveChanges();
            return student;
        }

        public List<Student> GetAllStudents()
        {
            var students=studentDbContext.Students.ToList();
            return students;
        }

        public Student? GetStudent(Guid id)
        {
            var student = studentDbContext.Students.FirstOrDefault(s => s.Id == id);
            if(student==null)
            {
                return null;
            }
            return student;
        }

        public Student? UpdateStudent(Guid id, Student student)
        {
            var _student = studentDbContext.Students.FirstOrDefault(s => s.Id == id);
            if(_student==null)
            {
                return null;
            }
            _student.Name=student.Name;
            studentDbContext.SaveChanges();
            return _student;
        }
    }
}
