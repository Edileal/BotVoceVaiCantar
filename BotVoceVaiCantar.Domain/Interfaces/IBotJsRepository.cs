namespace BotVoceVaiCantar.Domain.Interfaces
{
    public interface IBotJsRepository
    {
        public Task PostAsJsonNoContentAsync(string number, string data);
    }
}
