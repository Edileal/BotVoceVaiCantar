using BotVoceVaiCantar.Domain.Contracts;

namespace BotVoceVaiCantar.Domain.Interfaces
{
    public interface ICantorService
    {
        Task<CantorResponse> CriarAsync(CantorRequest request);
        Task<CantorResponse> AtualizarAsync(Guid? id, CantorRequest request);
        Task DeletarAsync(Guid id);
        Task<CantorResponse> ObterPorIdAsync(Guid id);
        Task EnviarCantorDiaAsync(LembreteRequest lembrete);
        Task<IEnumerable<CantorResponse>> ObterTodosAsync();
        Task<CantorResponse> AdicionarEOuAlterarData(DateTime dataNova, Guid id);
    }
}
