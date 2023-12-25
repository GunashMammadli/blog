using System.ComponentModel.DataAnnotations;

namespace Gunash_Blog.Areas.Admin.ViewModels.SliderVM
{
    public class SliderUpdateVM
    {
        [Required, MaxLength(32), MinLength(6)]
        public string Title { get; set; }
        [Required, MaxLength(32), MinLength(6)]
        public string Text { get; set; }
        [Required]
        public IFormFile ImagePath { get; set; }
    }
}
