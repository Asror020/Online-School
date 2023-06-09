using AutoMapper;
using BLL.Services.Interfaces;
using Core.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        public UsersController(
            IWebHostEnvironment hostEnvironment,
            ILogger<UsersController> logger,
            IMapper mapper,
            IUserService userService) : base(hostEnvironment, logger, mapper)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(User user)
        {
            var createdUser = await _userService.CreateAsync(user);

            return createdUser != null ? Ok(createdUser) : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, User entity)
        {
            var result = await _userService.UpdateAsync(id, entity);

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _userService.DeleteByIdAsync(id);

            return result ? NoContent() : NotFound();
        }
    }
}
