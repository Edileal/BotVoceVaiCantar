using BotVoceVaiCantar.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotVoceVaiCantar.Domain.Interfaces
{
    public interface IBotJsRepository
    {
        public Task PostAsJsonNoContentAsync(LembreteRequest request);
    }
}
