using Api.Dtos;
using AutoMapper;
using BLL.Services.Interfaces;
using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    public class StudentsController : BaseController
    {
        private readonly IStudentService _studentService;
        private readonly IRepositoryBase<Student> _studentRepos;
        public StudentsController(
            IWebHostEnvironment hostEnvironment,
            ILogger<StudentsController> logger,
            IMapper mapper,
            IStudentService studentService,
            IRepositoryBase<Student> studentRepos) : base(hostEnvironment, logger, mapper)
        {
            _studentService = studentService;
            _studentRepos = studentRepos;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _studentService.GetAllAsync();

            return Ok(Mapper.Map<IEnumerable<Student>>(result));
        }

        [HttpGet("{id}")]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentDto entity)
        {
            var result = await _studentService.UpdateAsync(id, Mapper.Map<Student>(entity));

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _studentService.DeleteByIdAsync(id);

            return result ? NoContent() : BadRequest();
        }

        [HttpGet("byAge")]
        public IActionResult GetStudentsByAge(int age)
        {
            var dayNow = DateTime.UtcNow.Day;
            var monthNow = DateTime.UtcNow.Month;
            var yearNow = DateTime.UtcNow.Year;

            var students = _studentRepos.Context.Students.
                Where(x => x.User.DateOfBirth <= DateTime.ParseExact($"{dayNow}/{monthNow}/{yearNow - age}", "dd/MM/yyyy", null))
                .Include(x => x.User).ToList();

            return Ok(Mapper.Map<IEnumerable<StudentDto>>(students));
        }

        [HttpGet("ByDate")]
        public IActionResult GetStudentsByDate(string startDate, string endDate)
        {

            var students = _studentRepos.Context.Students.
                Where(x => x.User.DateOfBirth.Month >= DateTime.ParseExact(startDate, "MMMM dd", null).Month
                 && x.User.DateOfBirth.Day >= DateTime.ParseExact(startDate, "MMMM dd", null).Day
                 && x.User.DateOfBirth.Month <= DateTime.ParseExact(endDate, "MMMM dd", null).Month 
                 && x.User.DateOfBirth.Day <= DateTime.ParseExact(endDate, "MMMM dd", null).Day)
                .Include(x => x.User).ToList();

            return Ok(Mapper.Map<IEnumerable<StudentDto>>(students));
        }

        [HttpGet("by-phone-number")]
        public IActionResult GetProfessorsByPhoneNumber(string code1, string code2)
        {
            var students = _studentRepos.Context.Students
                .Where(x => x.User.PhoneNumber.Contains("+998" + code1)
                || x.User.PhoneNumber.Contains("+998" + code2))
                .Include(x => x.User).ToList();

            return Ok(Mapper.Map<IEnumerable<StudentDto>>(students));
        }

        [HttpGet("search")]
        public IActionResult SearchStudent(string phrase)
        {
            var students = _studentRepos.Context.Students
                .Where(x => x.User.FirstName.ToLower().Contains(phrase.ToLower())
                || x.User.LastName.ToLower().Contains(phrase.ToLower()))
                .Include(x => x.User).ToList();

            return Ok(Mapper.Map<IEnumerable<StudentDto>>(students));
        }
    }
}
