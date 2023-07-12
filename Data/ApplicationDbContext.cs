using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoreMvc.Models;

namespace CoreMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CoreMvc.Models.Shinobi>? Shinobi { get; set; }
        public DbSet<CoreMvc.Models.NinjaClan>? NinjaClan { get; set; }
    }
}