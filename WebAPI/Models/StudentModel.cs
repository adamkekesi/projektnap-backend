using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class StudentModel
    {
        public int id { get; set; }
        [Required]
        [StringLength(200)]
        public string? name { get; set; }
        [Required]
        [StringLength(200)]
        public string? email { get; set; }
        [StringLength(20)]
        public string? phoneNumber { get; set; }
        //connections
        public IList<LessonModel>? lessons { get; set; }
    }
}