using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectSchool.Application.Interfaces;

namespace ProjectSchool.Tests.Students
{
    public class StudentTest
    {
        private readonly IStudentService _service;

        public StudentTest()
        {
            _service = new StudentServiceFake();
        }
    }
}