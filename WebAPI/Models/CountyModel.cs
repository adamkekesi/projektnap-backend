using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class CountyModel
    {
        public int id { get; set; }
        [Required]
        public string? name { get; set; }
    }
}