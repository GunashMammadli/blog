using Gunash_Blog.Areas.Admin.ViewModels.SliderVM;
using Gunash_Blog.Context;
using Gunash_Blog.Helpers;
using Gunash_Blog.Models;
using Gunash_Blog.ViewModels.SliderVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace Gunash_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        BlogDbContext _db { get; }
        IWebHostEnvironment _environment { get; }

        public SliderController(BlogDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var slider = await _db.Sliders.Select(s=> new SliderListItemVM
            {
                Id = s.Id,
                ImagePath = s.ImagePath,
                Text = s.Text,
                Title = s.Title
            }).ToListAsync();
            return View(slider);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM vm)
        {
            if(!ModelState.IsValid) { return  View(vm); }
            Slider slider = new Slider
            {
                Text = vm.Text,
                Title = vm.Title,
                ImagePath = await vm.ImagePath.Save(ImagesPath.slider)
            };
            await _db.Sliders.AddAsync(slider);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            _db.Sliders.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            SliderUpdateVM vm = new SliderUpdateVM
            {
                Title = data.Title,
                Text = data.Text,
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, SliderUpdateVM vm)
        {
            if (id == null) return BadRequest();
            var data = await _db.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            if (!ModelState.IsValid) { return View(vm); }
            data.Title = vm.Title;
            data.Text = vm.Text;
            data.ImagePath = await vm.ImagePath.Save(ImagesPath.slider);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
