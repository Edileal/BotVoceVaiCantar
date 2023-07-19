using BotVoceVaiCantar.Domain.Contracts;

namespace BotVoceVaiCantar.Domain.Interfaces
{
    public interface IAutenticacaoService
    {
        Task<AutenticacaoResponse> AutenticarAsync(AutenticacaoRequest request);
    }
}
