using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectSchool.Domain.Models;

namespace ProjectSchool.Persistence.Interfaces
{
    public interface IStudentRepository
    {
        void Add(Student student);
        void Update(Student student);
        void Delete(Student student);
        Task<bool> SaveChangesAsync();
        Task<Student> GetById(int Id);
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetByRa(string ra);
    }
}