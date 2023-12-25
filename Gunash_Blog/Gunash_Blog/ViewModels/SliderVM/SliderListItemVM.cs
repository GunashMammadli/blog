using System.ComponentModel.DataAnnotations;

namespace Gunash_Blog.ViewModels.SliderVM
{
    public class SliderListItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
    }
}
