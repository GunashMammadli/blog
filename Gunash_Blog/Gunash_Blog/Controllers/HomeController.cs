using Gunash_Blog.Context;
using Gunash_Blog.Models;
using Gunash_Blog.ViewModels.SliderVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Gunash_Blog.Controllers
{
    public class HomeController : Controller
    {
        BlogDbContext _db { get; }

        public HomeController(BlogDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        { 
            var slider = await _db.Sliders.Select(s => new SliderListItemVM
            {
                ImagePath = s.ImagePath,
                Text = s.Text,
                Title = s.Title,
                Id = s.Id,
            }).ToListAsync();
            return View(slider);
        }
    }
}
