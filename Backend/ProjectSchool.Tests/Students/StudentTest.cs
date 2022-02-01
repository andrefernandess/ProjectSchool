using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectSchool.Application.Interfaces;
using ProjectSchool.Domain.Models;
using Xunit;
using ExpectedObjects;

namespace ProjectSchool.Tests.Students
{
    public class StudentTest
    {

        [Fact]
        public void DeveCriarEstudante()
        {
            var student_esperado = new Student{
                Id = 1,
                Name = "Estudante 1",
                Email = "estudante1@email.com",
                Cpf = "33333333322",
                Ra = "555666777888"
            };

            var student = new Student{
                Id = student_esperado.Id,
                Name = student_esperado.Name, 
                Cpf = student_esperado.Cpf, 
                Email = student_esperado.Email, 
                Ra = student_esperado.Ra 
                };

            student_esperado.ToExpectedObject().ShouldMatch(student);
        }
    }
}