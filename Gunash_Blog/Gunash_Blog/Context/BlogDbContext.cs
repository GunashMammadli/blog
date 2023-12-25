using Gunash_Blog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gunash_Blog.Context
{
    public class BlogDbContext : IdentityDbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Slider> Sliders { get; set; }
    }
}
