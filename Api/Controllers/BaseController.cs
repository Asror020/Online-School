using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController()]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected readonly IWebHostEnvironment HostEnvironment;
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;

        public BaseController(IWebHostEnvironment hostEnvironment, ILogger logger, IMapper mapper)
        {
            HostEnvironment = hostEnvironment;
            Logger = logger;
            Mapper = mapper;
        }
    }
}
