using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : Controller
    {
        private readonly DataContext dbContext;
        public ApiController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet("get-all-teacher")]
        public IActionResult Teachers()
        {
            return Ok(
                dbContext.Set<TeacherModel>().Select(t=> new
                {
                    t.id,
                    t.email,
                    t.name,
                    t.phoneNumber,
                })
            );
        }
    }
}
