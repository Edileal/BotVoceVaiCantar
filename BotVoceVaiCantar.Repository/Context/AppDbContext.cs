using BotVoceVaiCantar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BotVoceVaiCantar.Repository.Context
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

        public DbSet<Cantor> Cantor { get; set; }
        
    }
}
