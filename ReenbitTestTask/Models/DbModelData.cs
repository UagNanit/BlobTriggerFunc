using System.ComponentModel.DataAnnotations;

namespace ReenbitTestTask.Models
{
    public class DbModelData
    {
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? FileName { get; set; }
    }
}
