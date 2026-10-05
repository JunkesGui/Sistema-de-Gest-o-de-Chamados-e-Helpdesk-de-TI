using Microsoft.EntityFrameworkCore;
using HelpDesk.API.Models.Entities;
using HelpDesk.API.Data;

namespace HelpDesk.API.Repositories
{
    public class CategoriasRepository
    {
        private readonly AppDbContext _context;

        public CategoriasRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task<Categoria?> GetOneAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Categorias.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> HasChamadosAsync(int categoriaId)
        {
            return await _context.Chamados.AnyAsync(c => c.CategoriaId == categoriaId);
        }

        public async Task CreateAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }
    }
}