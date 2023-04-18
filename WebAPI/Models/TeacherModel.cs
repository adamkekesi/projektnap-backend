using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class TeacherModel
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
        //public int? rate { get; set; }
    }
}