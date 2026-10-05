using HelpDesk.API.Repositories;
using HelpDesk.API.Models.Entities;

namespace HelpDesk.API.Services
{
    public class CategoriasService
{
        private readonly CategoriasRepository _repository;

        public CategoriasService(CategoriasRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Categoria>> Getall()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Categoria> GetOne(int id)
        {
            return await _repository.GetOneAsync(id);
        }

        public async Task Create(Categoria categoria)
        {
            await _repository.CreateAsync(categoria);
        }

        public async Task Update(Categoria categoria)
        {
            await _repository.UpdateAsync(categoria);
        }

        public async Task Delete(int id)
        {
            var categoria = await _repository.GetOneAsync(id);
            if (categoria == null)
            {
                throw new Exception("Nenhuma categoria encontrada.");
            }

            await _repository.DeleteAsync(categoria);
        }
    }
}