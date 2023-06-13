namespace BotVoceVaiCantar.Domain.Entities
{
    public class Cantor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Telefone { get; set; }
        public DateTime Data { get; set; }
        public bool? Suspenso { get; set; }
    }
}