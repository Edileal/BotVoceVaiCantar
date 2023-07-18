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
        public CantorService(ICantorRepository cantorRepository, IMapper mapper)
        {
            _cantorRepository = cantorRepository;
            _mapper = mapper;
        }

        public async Task<CantorResponse> AtualizarAsync(Guid? id, CantorRequest request)
        {
            var cantorEntity = await _cantorRepository.FindAsync(id);
            if(cantorEntity is null)
            {
                throw new ArgumentNullException("Cantor não encontrado");
            }
            await _cantorRepository.EditAsync(cantorEntity);
            return _mapper.Map<CantorResponse>(cantorEntity);
        }

        public async Task<CantorResponse> CriarAsync(CantorRequest request)
        {
            if(request.Name is null)
            {
                throw new ArgumentException("Nome não pode ser nulo");
            }
            if (request.Telefone is null)
            {
                throw new ArgumentException("Telefone não pode ser nulo");
            }
            var cantorEntity = _mapper.Map<Cantor>(request);
            await _cantorRepository.AddAsync(cantorEntity);
            return _mapper.Map<CantorResponse>(cantorEntity);
        }

        public async Task DeletarAsync(Guid id)
        {
            await ObterPorIdAsync(id);          
            //está dessa forma apenas para eu testar se funciona a validação dessa forma
            await _cantorRepository.RemoveAsync(id);
        }

        public async Task<CantorResponse> ObterPorIdAsync(Guid id)
        {
            var cantorEntity = await _cantorRepository.FindAsync(id);
            if (cantorEntity is null)
            {
                throw new ArgumentNullException("Cantor não encontrado");
            }
            return _mapper.Map<CantorResponse>(cantorEntity);
        }

        public async Task<IEnumerable<CantorResponse>> ObterTodosAsync()
        {
            var listaCantor = await _cantorRepository.ListAsync();
            if (listaCantor is null)
            {
                throw new ArgumentNullException("Não há cantores cadastrados");
            }
            return _mapper.Map<IEnumerable<CantorResponse>>(listaCantor);
        }

        public async Task<CantorResponse> AdicionarEOuAlterarData(DateTime dataNova, Guid id)
        {
            var cantorEntity = await _cantorRepository.FindAsync(id);
            if (cantorEntity is null)
            {
                throw new ArgumentNullException("Não há cantores cadastrados");
            }
            cantorEntity.Data = dataNova;
            await _cantorRepository.EditAsync(cantorEntity);
            return _mapper.Map<CantorResponse>(cantorEntity);
        }
    }
}