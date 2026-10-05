using HelpDesk.API.Middlewares.Exceptions;
using HelpDesk.API.Models.Entities;
using HelpDesk.API.Repositories;

namespace HelpDesk.API.Services
{
    public class CategoriasService
    {
        private readonly CategoriasRepository _repository;

        public CategoriasService(CategoriasRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Categoria>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Categoria> GetOne(int id)
        {
            return await _repository.GetOneAsync(id)
                ?? throw new NotFoundException($"Categoria {id} não encontrada.");
        }

        public async Task<Categoria> Create(Categoria categoria)
        {
            categoria.Id = 0;
            categoria.Chamados = new List<Chamado>();

            await _repository.CreateAsync(categoria);
            return categoria;
        }

        public async Task<Categoria> Update(int id, Categoria dados)
        {
            var categoria = await GetOne(id);
            categoria.Nome = dados.Nome;

            await _repository.UpdateAsync(categoria);
            return categoria;
        }

        public async Task Delete(int id)
        {
            var categoria = await GetOne(id);

            if (await _repository.HasChamadosAsync(id))
                throw new BusinessException(
                    "Não é possível excluir a categoria pois existem chamados associados a ela.");

            await _repository.DeleteAsync(categoria);
        }
    }
}
