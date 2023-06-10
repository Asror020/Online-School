using Api.Dtos;
using AutoMapper;
using BLL.Services.Interfaces;
using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class GradeController : BaseController
    {
        private readonly IRepositoryBase<Grade> _gradeRepo;
        private readonly IBaseService<Grade> _gradeService;
        private readonly IStudentService _studentService;
        private readonly IRepositoryBase<Subject> _subjectRepo;

        public GradeController(
            IWebHostEnvironment hostEnvironment,
            ILogger<GradeController> logger,
            IMapper mapper,
            IBaseService<Grade> gradeService,
            IRepositoryBase<Grade> gradeRepo,
            IStudentService studentService,
            IRepositoryBase<Subject> subjectRepo) : base(hostEnvironment, logger, mapper)
        {
            _gradeService = gradeService;
            _gradeRepo = gradeRepo;
            _studentService = studentService;
            _subjectRepo = subjectRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _gradeService.GetByIdAsync(id);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GradeDto entity)
        {
            var result = await _gradeService.CreateAsync(Mapper.Map<Grade>(entity));

            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, GradeDto entity)
        {
            var grade = await _gradeService.GetByIdAsync(id);

            entity.Score = grade.Score;

            var result = await _gradeService.UpdateAsync(id, grade);

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _gradeService.DeleteByIdAsync(id);

            return result ? NoContent(): NotFound();
        }

        [HttpGet("student-highest-score")]
        public IActionResult GetHighestStudentScore(int studentId)
        {
            var studentGrades = _gradeRepo.Get(x => x.StudentId == studentId).ToList();
            var highestGrade = studentGrades.MaxBy(x => x.Score);

            var subject = _subjectRepo.Get(x => x.Name == highestGrade.SubjectName).FirstOrDefault();

            return subject != null ? Ok(subject) : BadRequest();
        }
    }

}
