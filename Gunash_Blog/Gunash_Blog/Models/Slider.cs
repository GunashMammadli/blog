using System.ComponentModel.DataAnnotations;

namespace Gunash_Blog.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required, MaxLength(32), MinLength(6)]
        public string Title { get; set; }
        [Required, MaxLength(32), MinLength(6)]
        public string Text { get; set; }
        [Required]
        public string ImagePath {  get; set; } 
    }
}
