using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    /**
     * enum for sexual orientation
     *
     * used by the model
     */
    public enum Sexes
    {
        Man,
        Woman,
        Other
    }

    /**
     * blog model
     * contains fields saved to the json objects in the json file
     *
     * each field contains its own validators
     */
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
        [Display(Name = "Looking for love")]
        public bool LookingForLove { get; set; }
        
        [Required]
        [Display(Name = "Sex")]
        public Sexes Sex { get; set; }
        
        [Required]
        public DateTime? Time { get; set; }
    }
}