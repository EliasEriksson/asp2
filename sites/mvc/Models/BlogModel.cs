using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class BlogModel
    {
        [Required]
        public string? Id { get; set; }

        [Required]
        [Display(Name = "User:")]
        public string? User { get; init; }
    
        [Required]
        [Display(Name = "Content:")]
        public string? Content { get; init; }
        
        [Required]
        public DateTime? Time { get; set; }
    }
}