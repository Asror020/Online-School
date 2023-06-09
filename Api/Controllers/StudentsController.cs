using Api.Dtos;
using AutoMapper;
using BLL.Services.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class StudentsController : BaseController
    {
        private readonly IStudentService _studentService;
        public StudentsController(
            IWebHostEnvironment hostEnvironment,
            ILogger<StudentsController> logger,
            IMapper mapper,
            IStudentService studentService) : base(hostEnvironment, logger, mapper)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);

            return student == null ? NotFound() : Ok(Mapper.Map<StudentDto>(student));
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentDto entity)
        {
            var result = await _studentService.CreateAsync(Mapper.Map<Student>(entity));

            return result == null ? BadRequest() : Ok(Mapper.Map<StudentDto>(result)); 
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, StudentDto entity)
        {
            var result = await _studentService.UpdateAsync(id, Mapper.Map<Student>(entity));

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _studentService.DeleteByIdAsync(id);

            return result ? NoContent() : BadRequest();
        }
    }
}
