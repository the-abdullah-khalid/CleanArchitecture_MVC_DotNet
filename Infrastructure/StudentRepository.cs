using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (student == null)
            {
                return null;
            }
            studentDbContext.Students.Remove(student);
            studentDbContext.SaveChanges();
            return student;
        }

        public List<Student> GetAllStudents()
        {
            return studentDbContext.Students.ToList();
        }

        public Student? GetStudent(Guid id)
        {
            return studentDbContext.Students.FirstOrDefault(s => s.Id == id);
        }

        public Student? UpdateStudent(Guid id, Student updatedStudent)
        {
            var student = studentDbContext.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return null;
            }

            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.Gender = updatedStudent.Gender;
            student.Email = updatedStudent.Email;
            student.Phone = updatedStudent.Phone;
            student.DateOfBirth = updatedStudent.DateOfBirth;

            studentDbContext.SaveChanges();
            return student;
        }
    }
}
