using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectSchool.Application.Interfaces;
using ProjectSchool.Domain.Models;

namespace ProjectSchool.Tests.Students
{
    public class StudentServiceFake : IStudentService
    {
        private readonly List<Student> _students;

        public StudentServiceFake()
        {
            _students = new List<Student>()
            {
                new Student(){ Id = 1, Name = "Andre", Email = "email@email.com", Cpf = "33322211188", Ra = "123456" },
                new Student(){ Id = 1, Name = "Melissa", Email = "email@email.com", Cpf = "33322211188", Ra = "654321" }
            };
        }

        public Task<Student> Add(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetByRa(string ra)
        {
            throw new NotImplementedException();
        }

        public Task<Student> Update(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}