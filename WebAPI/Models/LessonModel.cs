using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class LessonModel
    {
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        public string? subject { get; set; }
        [Required]
        [StringLength(50)]
        public string? grade { get; set; }
        [Required]
        [StringLength(255)]
        public string? place { get; set; }
        public int price { get; set; }
        public DateTime date { get; set; }
    }
}