using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool.Application.Dtos;
using ProjectSchool.Application.Interfaces;

namespace ProjectSchool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var students = await _service.GetAll();

                if(students == null) return NotFound("Nenhum dado encontrado");

                return Ok(students);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar recuperar os dados. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var student = await _service.GetById(id);

                if(student == null) return NotFound("Nenhum dado encontrado");

                return Ok(student);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar recuperar os dados. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentDto model)
        {
            try
            {
                var student = await _service.Add(model);

                if(student == null) return BadRequest("Erro ao adicionar.");

                return Ok(student);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar adicionar os dados. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, StudentDto model)
        {
            try
            {
                var student = await _service.Update(id, model);

                if(student == null) return BadRequest("Erro ao adicionar.");

                return Ok(student);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar atualizar os dados. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if(await _service.Delete(id))
                    return Ok("Informacao deletada");
                else
                    return BadRequest("Informacao nao deletada.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar deletar os dados. Erro: {ex.Message}");
            }
        }
    }
}