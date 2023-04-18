using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return this.Run(() =>
            {
                return Ok(_teacherService.GetAll());
            });
        }
    }
}
