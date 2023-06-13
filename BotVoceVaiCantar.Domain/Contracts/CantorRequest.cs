using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotVoceVaiCantar.Domain.Contracts
{
    public class CantorRequest
    {
        public string Name { get; set; }
        public int Telefone { get; set; }
        public DateTime Data { get; set; }
    }
}
