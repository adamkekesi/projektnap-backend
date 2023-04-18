using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class TeacherModel
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
        public CountyModel county { get; set; } = null!;
        public int countyId { get; set; }
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