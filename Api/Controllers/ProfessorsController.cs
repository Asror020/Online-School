using Api.Dtos;
using AutoMapper;
using BLL.Services.Interfaces;
using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Api.Controllers
{
    public class ProfessorsController : BaseController
    {
        private readonly IProfessorService _professorService;
        private readonly IRepositoryBase<Professor> _professorRepo;
        private readonly IRepositoryBase<Subject> _subjectRepo;
        private readonly IRepositoryBase<Grade> _gradeRepo;
        public ProfessorsController(
            IWebHostEnvironment hostEnvironment,
            ILogger<ProfessorsController> logger,
            IMapper mapper,
            IProfessorService professorService,
            IRepositoryBase<Professor> professorRepo,
            IRepositoryBase<Subject> subjectRepo,
            IRepositoryBase<Grade> gradeRepo) : base(hostEnvironment, logger, mapper)
        {
            _professorService = professorService;
            _professorRepo = professorRepo;
            _subjectRepo = subjectRepo;
            _gradeRepo = gradeRepo;
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

        [HttpGet("byAge")]
        public IActionResult GetProfessorsByAge(int age)
        {
            var dayNow = DateTime.UtcNow.Day;
            var monthNow = DateTime.UtcNow.Month;
            var yearNow = DateTime.UtcNow.Year;

            var professors = _professorRepo.Context.Professors.
                Where(x => x.User.DateOfBirth <= DateTime.ParseExact($"{dayNow}/{monthNow}/{yearNow - age}", "d/M/yyyy", null))
                .Include(x => x.User).ToList();

            return Ok(Mapper.Map<IEnumerable<ProfessorDto>>(professors));
        }

        [HttpGet("by-phone-number")]
        public IActionResult GetProfessorsByPhoneNumber(string code1, string code2)
        {
            var professors = _professorRepo.Context.Professors
                .Where(x => x.User.PhoneNumber.Contains("+998" + code1) 
                || x.User.PhoneNumber.Contains("+998" + code2))
                .Include(x => x.User).ToList();

            return Ok(Mapper.Map<IEnumerable<ProfessorDto>>(professors));
        }

        [HttpGet("highest-score-subject")]
        public async Task<IActionResult> GetHighestScoreSubjectPf()
        {
            var gradesOver97 = _gradeRepo.Get(x => x.Score >= 97).ToList();

            var subjects = new List<Subject>();

            while(gradesOver97.Count > 0)
            {
                subjects.Add(_subjectRepo.Get(x => x.Name == gradesOver97[0].SubjectName).SingleOrDefault());
                gradesOver97.RemoveAll(x => x.SubjectName == gradesOver97[0].SubjectName);
            }

            var profs = new List<Professor>();

            while(subjects.Count > 0)
            {
                profs.Add(await _professorService.GetByIdAsync(subjects[0].ProfessorId));
                subjects.RemoveAll(x => x.ProfessorId == subjects[0].ProfessorId);
            }

            return Ok(Mapper.Map<IEnumerable<ProfessorDto>>(profs));
        }
    }
}
