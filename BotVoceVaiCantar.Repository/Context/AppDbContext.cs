using BotVoceVaiCantar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BotVoceVaiCantar.Repository.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cantor> Cantores { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

       
    }
}
