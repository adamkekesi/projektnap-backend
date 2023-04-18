using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using System.Net;
using System.Net.Http;
using System.Web;
using System.IO;

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

        [HttpGet("teacher/{id}")]
        public IActionResult Teacher(string id)
        {
            if (!int.TryParse(id, out int teacherId))
            {
                return NotFound("Teacher is not exist");
            }
            var teacher = dbContext.Set<TeacherModel>()
                                   .SingleOrDefault(p => p.id == teacherId);
            if (teacher == null)
            {
                return NotFound("Teacher is not exist");
            }
            return Ok(new
            {
                teacher.id,
                teacher.price,
                teacher.isOnline,
                teacher.subject,
                teacher.grade,
                teacher.countyId,
                teacher.name,
                teacher.email,
                teacher.phoneNumber,

            });
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

        [HttpGet("get-all-county")]
        public IActionResult GetAllCounty()
        {
            return Ok(
            dbContext.Set<CountyModel>()
                .Select(c => new { c.id, c.name }));
        }

        [HttpGet("get-all-lessons")]
        public IActionResult Lessons()
        {
            return Ok(
                dbContext.Set<LessonModel>().Select(t => new
                {
                    t.id,
                    t.date,
                    t.student,
                    t.teacher
                })
            );
        }


        [HttpPost("apply-for-lesson")]
        public IActionResult ApplyForLesson(int teacherIdFromBody, int studentIdFromBody, DateTime dateFromBody)
        {
            var t = dbContext.Set<TeacherModel>().FirstOrDefault(t => t.id == teacherIdFromBody);
            var s = dbContext.Set<StudentModel>().FirstOrDefault(s => s.id == studentIdFromBody);

            if (t == null)
            {
                return BadRequest("Nincs ilyen tanár!");
            }

            if (s == null)
            {
                return BadRequest("Nincs ilyen diák!");
            }

            var l = new LessonModel { date = dateFromBody, teacher = t, student = s };
            dbContext.Set<LessonModel>().Add(l);
                        dbContext.SaveChanges();
            return Ok(
                        l
                     );
        }

    }
}
