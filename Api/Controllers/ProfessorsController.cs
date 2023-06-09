using Api.Dtos;
using AutoMapper;
using BLL.Services.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ProfessorsController : BaseController
    {
        private readonly IProfessorService _professorService;
        public ProfessorsController(
            IWebHostEnvironment hostEnvironment,
            ILogger<ProfessorsController> logger,
            IMapper mapper,
            IProfessorService professorService) : base(hostEnvironment, logger, mapper)
        {
            _professorService = professorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _professorService.GetByIdAsync(id);

            return result == null ? NotFound() : Ok(Mapper.Map<ProfessorDto>(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfessorDto entity)
        {
            var result = await _professorService.CreateAsync(Mapper.Map<Professor>(entity));

            return result == null ? BadRequest() : Ok(Mapper.Map<ProfessorDto>(result));
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, ProfessorDto entity)
        {
            var result = await _professorService.UpdateAsync(id, Mapper.Map<Professor>(entity));

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _professorService.DeleteByIdAsync(id);

            return result ? NoContent() : NotFound();
        }
    }
}
