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

        [HttpGet("search-teacher")]
        public IActionResult Search([FromQuery] string? subject, [FromQuery] string? grade, [FromQuery] int? countyId, [FromQuery] int? priceCategoryId)
        {
            return Ok(
            dbContext.Set<TeacherModel>()
                .Where(t => (subject == null || t.subject.Contains(subject))
                     && (grade == null || t.grade.Contains(grade))
                     && (countyId == null || t.countyId == countyId)
                     && (priceCategoryId == null ||
                     ((t.price <= 500 && priceCategoryId==0) ||
                     (t.price <= 1000 && priceCategoryId == 1) || 
                     (t.price <= 1500 && priceCategoryId == 2) || 
                     (t.price <= 2000 && priceCategoryId == 3) || 
                     (t.price > 2000 && priceCategoryId == 4)))));
        }
    }
}
