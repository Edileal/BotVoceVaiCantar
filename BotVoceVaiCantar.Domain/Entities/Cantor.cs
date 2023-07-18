namespace BotVoceVaiCantar.Domain.Entities
{
    public class Cantor
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Telefone { get; set; }
        public DateTime? Data { get; set; }
        public bool? Suspenso { get; set; }
    }
}