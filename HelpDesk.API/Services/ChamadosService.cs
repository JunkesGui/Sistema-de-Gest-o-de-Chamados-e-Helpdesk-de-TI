using HelpDesk.API.Middlewares.Exceptions;
using HelpDesk.API.Models.Entities;
using HelpDesk.API.Repositories;

namespace HelpDesk.API.Services
{
    public class ChamadosService
    {
        private readonly ChamadosRepository _cRepository;
        private readonly InteracoesRepository _iRepository;
        private readonly CategoriasRepository _catRepository;

        public ChamadosService(
            ChamadosRepository cRepository,
            InteracoesRepository iRepository,
            CategoriasRepository catRepository)
        {
            _cRepository = cRepository;
            _iRepository = iRepository;
            _catRepository = catRepository;
        }

        public async Task<Chamado> StartChamado(Chamado chamado)
        {
            if (!Enum.IsDefined(chamado.Prioridade))
                throw new BusinessException("Prioridade inválida. Use Baixa, Media ou Alta.");

            if (!await _catRepository.ExistsAsync(chamado.CategoriaId))
                throw new BusinessException($"A categoria {chamado.CategoriaId} não existe.");

            // Campos controlados pelo sistema: ignora o que veio do cliente.
            chamado.Id = 0;
            chamado.Status = StatusEnum.Aberto;
            chamado.DataAbertura = DateTime.Now;
            chamado.DataFechamento = null;
            chamado.Solucao = null;
            chamado.Categoria = null;
            chamado.Interacoes = new List<Interacao>();

            await _cRepository.CreateAsync(chamado);

            await _iRepository.CreateAsync(new Interacao
            {
                ChamadoId = chamado.Id,
                DataRegistro = DateTime.Now,
                Mensagem = "Chamado Aberto",
                Autor = "Admin"
            });

            return chamado;
        }

        public async Task<Chamado> GetOne(int id)
        {
            return await _cRepository.GetOneWithDetailsAsync(id)
                ?? throw new NotFoundException($"Chamado {id} não encontrado.");
        }

        public async Task<List<Chamado>> GetAll(StatusEnum? status, PrioridadeEnum? prioridade, int? categoriaId)
        {
            if (status.HasValue && !Enum.IsDefined(status.Value))
                throw new BusinessException("Status inválido. Use Aberto, EmAndamento ou Fechado.");

            if (prioridade.HasValue && !Enum.IsDefined(prioridade.Value))
                throw new BusinessException("Prioridade inválida. Use Baixa, Media ou Alta.");

            return await _cRepository.GetAllAsync(status, prioridade, categoriaId);
        }

        public async Task<Chamado> AttendtoChamado(int id)
        {
            var chamado = await GetTracked(id);

            if (chamado.Status != StatusEnum.Aberto)
                throw new BusinessException("Somente chamados com status Aberto podem ser iniciados.");

            chamado.Status = StatusEnum.EmAndamento;
            await _cRepository.UpdateAsync(chamado);
            return chamado;
        }

        public async Task<Chamado> EncerrarChamado(int id, string solucao)
        {
            if (string.IsNullOrWhiteSpace(solucao))
                throw new BusinessException("A solução é obrigatória para encerrar o chamado.");

            var chamado = await GetTracked(id);

            if (chamado.Status == StatusEnum.Fechado)
                throw new BusinessException("O chamado já está fechado.");

            chamado.Solucao = solucao.Trim();
            chamado.DataFechamento = DateTime.Now;
            chamado.Status = StatusEnum.Fechado;

            await _cRepository.UpdateAsync(chamado);
            return chamado;
        }

        public async Task<Interacao> AddInteraction(int id, Interacao interacao)
        {
            var chamado = await GetTracked(id);

            if (chamado.Status == StatusEnum.Fechado)
                throw new BusinessException("Não é possível adicionar interações em chamados fechados.");

            interacao.Id = 0;
            interacao.Chamado = null;
            interacao.ChamadoId = id;
            interacao.DataRegistro = DateTime.Now;

            await _iRepository.CreateAsync(interacao);
            return interacao;
        }

        private async Task<Chamado> GetTracked(int id)
        {
            return await _cRepository.GetOneAsync(id)
                ?? throw new NotFoundException($"Chamado {id} não encontrado.");
        }
    }
}
