using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TextGameAPI.Models;

namespace TextGameAPI.Data
{
    public class TextGameDbContext : IdentityDbContext<AppUser>
    {
        public TextGameDbContext(DbContextOptions<TextGameDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PlayerCharacter>? Characters { get; set; }
    }
}
