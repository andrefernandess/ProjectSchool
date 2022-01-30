using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectSchool.Application.Dtos;
using ProjectSchool.Domain.Models;

namespace ProjectSchool.Application.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDto> Add(StudentDto student);
        Task<StudentDto> Update(int id, StudentDto student);
        Task<bool> Delete(int id);
        Task<StudentDto> GetById(int id);
        Task<IEnumerable<StudentDto>> GetAll();
        Task<StudentDto> GetByRa(string ra);
    }
}