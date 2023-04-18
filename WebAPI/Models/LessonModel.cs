using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class LessonModel
    {
        public int id { get; set; }
        public int price { get; set; }
        public bool isOnline { get; set; }
        [Required]
        [StringLength(100)]
        public string? subject { get; set; }
        [Required]
        [StringLength(50)]
        public string? grade { get; set; }
        [Required]
        [StringLength(255)]
        public string? place { get; set; }
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