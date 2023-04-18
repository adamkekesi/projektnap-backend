using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class LessonModel
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        //connections
        [Required]
        public StudentModel student { get; set; } = null!;
        public int studentId { get; set; }

        [Required]
        public TeacherModel teacher { get; set; } = null!;
        public int teacherId { get; set; }
    }
}