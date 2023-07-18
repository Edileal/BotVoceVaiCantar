using BotVoceVaiCantar.Domain.Entities;
using BotVoceVaiCantar.Domain.Interfaces;
using BotVoceVaiCantar.Repository.Context;

namespace BotVoceVaiCantar.Repository.Repositories
{
    public class CantorRepository : BaseRepository<Cantor>, ICantorRepository
    {
        public CantorRepository(AppDbContext context) : base(context)
        {
        }
       
    }
}
