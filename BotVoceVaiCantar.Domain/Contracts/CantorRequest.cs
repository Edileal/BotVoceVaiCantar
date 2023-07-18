namespace BotVoceVaiCantar.Domain.Contracts
{
    public class CantorRequest
    {
        public string Name { get; set; }
        public string Telefone { get; set; }
        public DateTime? Data { get; set; }
    }
}
