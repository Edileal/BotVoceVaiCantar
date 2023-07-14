using AutoMapper;
using BotVoceVaiCantar.Domain.Contracts;
using BotVoceVaiCantar.Domain.Entities;
using BotVoceVaiCantar.Domain.Interfaces;

namespace BotVoceVaiCantar.Service.Services
{
    public class CantorService : ICantorService
    {
        private readonly IMapper _mapper;
        private readonly ICantorRepository _cantorRepository;
        private readonly IBotJsRepository _botJsRepository;
        public readonly HttpClient _httpClient;
        public CantorService(ICantorRepository cantorRepository, IMapper mapper, HttpClient httpClient)
        {
            _cantorRepository = cantorRepository;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<CantorResponse> AtualizarAsync(Guid? id, CantorRequest request)
        {
            var cantorEntity = await _cantorRepository.FindAsync(id);
            await _cantorRepository.EditAsync(cantorEntity);
            return _mapper.Map<CantorResponse>(cantorEntity);
        }

        public async Task<CantorResponse> CriarAsync(CantorRequest request)
        {
            var cantorEntity = _mapper.Map<Cantor>(request);
            await _cantorRepository.AddAsync(cantorEntity);
            return _mapper.Map<CantorResponse>(cantorEntity);
        }

        public async Task DeletarAsync(Guid id)
        {
            var cantorEntity = await _cantorRepository.FindAsync(id);
            await _cantorRepository.RemoveAsync(cantorEntity);
        }

        public async Task EnviarCantorDiaAsync(LembreteRequest lembrete)
        {
            await _botJsRepository.PostAsJsonNoContentAsync(lembrete); 
        }

        public async Task<CantorResponse> ObterPorIdAsync(Guid id)
        {
            var cantorEntity = await _cantorRepository.FindAsync(id);
            return _mapper.Map<CantorResponse>(cantorEntity);
        }

        public async Task<IEnumerable<CantorResponse>> ObterTodosAsync()
        {
            var listaCantor = await _cantorRepository.ListAsync();
            return _mapper.Map<IEnumerable<CantorResponse>>(listaCantor);
        }
    }
}