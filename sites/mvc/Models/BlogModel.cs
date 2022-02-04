using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public enum Sexes
    {
        Male,
        Female,
        Other
    }

    public class BlogModel
    {
        [Required]
        public string? Id { get; set; }

        [Required]
        [Display(Name = "User:")]
        [MaxLength(50)]
        public string? User { get; init; }
    
        [Required]
        [Display(Name = "Content:")]
        [MaxLength(255)]
        public string? Content { get; init; }
        
        [Required]
        public bool LookingForLove { get; set; }
        
        [Required]
        public Sexes Sex { get; set; }
        
        [Required]
        public DateTime? Time { get; set; }
    }
}