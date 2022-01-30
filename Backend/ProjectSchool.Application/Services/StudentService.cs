using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ProjectSchool.Application.Dtos;
using ProjectSchool.Application.Interfaces;
using ProjectSchool.Domain.Models;
using ProjectSchool.Persistence.Interfaces;

namespace ProjectSchool.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<StudentDto> Add(StudentDto studentDto)
        {
            try
            {
                var validar_ra = await GetByRa(studentDto.Ra);

                if(validar_ra != null) throw new Exception("Erro ao adicionar. RA ja existe na base.");

                var student = _mapper.Map<Student>(studentDto);
                _repository.Add(student);

                if(await _repository.SaveChangesAsync())
                    return _mapper.Map<StudentDto>(await _repository.GetById(student.Id));

                return null;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<StudentDto> Update(int id, StudentDto student)
        {
            try
            {
                var student_base = await _repository.GetById(id);

                if(student_base == null) return null;

                student.Id = student_base.Id;

                _mapper.Map(student, student_base);

                _repository.Update(student_base);

                if(await _repository.SaveChangesAsync())
                    return _mapper.Map<StudentDto>(await _repository.GetById(student.Id));

                return null;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var student = await _repository.GetById(id);

                if(student == null) throw new Exception("Registro nao encontrado");

                _repository.Delete(student);

                return await _repository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            } 
        }

        public async Task<IEnumerable<StudentDto>> GetAll()
        {
            try
            {
                var results = await _repository.GetAll();

                if(results ==  null) return null;

                var students = _mapper.Map<StudentDto[]>(results);

                return students;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<StudentDto> GetById(int id)
        {
            try
            {
                var result = await _repository.GetById(id);

                if(result ==  null) return null;

                var student = _mapper.Map<StudentDto>(result);

                return student;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<StudentDto> GetByRa(string ra)
        {
            try
            {
                var result = await _repository.GetByRa(ra);

                if(result ==  null) return null;

                var student = _mapper.Map<StudentDto>(result);

                return student;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}