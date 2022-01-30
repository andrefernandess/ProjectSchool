using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjectSchool.Application.Dtos;
using ProjectSchool.Domain.Models;

namespace ProjectSchool.Application.Helpers
{
    public class ProjectSchoolProfile : Profile
    {
        public ProjectSchoolProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}