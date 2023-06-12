using Api.Dtos;
using AutoMapper;
using BLL.Services.Interfaces;
using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class SubjectsController : BaseController
    {
        private readonly IRepositoryBase<Subject> _subjectRepo;
        private readonly IBaseService<Subject> _subjectService;
        private readonly IRepositoryBase<Grade> _gradeRepo;
        public SubjectsController(
            IWebHostEnvironment hostEnvironment,
            ILogger<SubjectsController> logger,
            IMapper mapper,
            IRepositoryBase<Subject> subjectRepo,
            IBaseService<Subject> subjectService,
            IRepositoryBase<Grade> gradeRepo) : base(hostEnvironment, logger, mapper)
        {
            _subjectRepo = subjectRepo;
            _subjectService = subjectService;
            _gradeRepo = gradeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _subjectService.GetAllAsync();

            return result != null ? Ok(Mapper.Map<IEnumerable<SubjectDto>>(result)) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _subjectService.GetByIdAsync(id);

            return result != null ? Ok(Mapper.Map<SubjectDto>(result)) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubjectDto entity)
        {
            var result = await _subjectService.CreateAsync(Mapper.Map<Subject>(entity));

            return result != null ? Ok(Mapper.Map<SubjectDto>(result)) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SubjectDto entity)
        {
            var subject = await _subjectService.GetByIdAsync(id) ?? throw new EntryPointNotFoundException();

            subject.StudentsList = entity.StudentsList;
            subject.ProfessorId = entity.ProfessorId;
            subject.Name = entity.Name;

            var result = await _subjectService.UpdateAsync(id, subject);

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _subjectService.DeleteByIdAsync(id);

            return result ? NoContent() : NotFound();
        }

        [HttpGet("by-pf")]
        public IActionResult GetSubjectByPf(int professorId)
        {
            var subjects = _subjectRepo.Get(x => x.ProfessorId == professorId).ToList();

            var result = new List<Subject>();

            foreach(var subject in subjects)
            {
                var grades = _gradeRepo.Get(x => x.SubjectName == subject.Name && x.Score >= 80).ToList();

                if (grades.Count() >= 10) result.Add(subject);
            }

            return Ok(Mapper.Map<IEnumerable<SubjectDto>>(result));
        }

        [HttpGet("highestScore")]
        public async Task<IActionResult> GetHighestScoreSubject()
        {
            var subjects = await _subjectService.GetAllAsync();

            var result = new Subject();

            long max = 0;

            foreach(var subject in subjects)
            {
                var averageScore = 0;
                var grades = _gradeRepo.Get(x => x.SubjectName == subject.Name).ToList();

                foreach(var grade in grades)
                {
                    averageScore += grade.Score;
                }

                averageScore = averageScore / grades.Count();

                if (averageScore > max)
                {
                    max = averageScore;
                    result = subject;
                }
            }

            return Ok(Mapper.Map<SubjectDto>(result));
        }
    }
}
