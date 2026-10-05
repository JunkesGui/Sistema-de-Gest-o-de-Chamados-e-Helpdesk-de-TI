using Microsoft.EntityFrameworkCore;
using HelpDesk.API.Models.Entities;
using HelpDesk.API.Data;

namespace HelpDesk.API.Repositories
{
    public class CategoriasRepository
    {
        private readonly AppDbContext _context;

        public CategoriasRepository(AppDbContext context){
            _context = context;
        }

        public async Task<List<Categoria>> GetAllAsync(){
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetOneAsync(string id){
            return await _context.Categorias.FindAsync(id);
        }

        public async Task CreateAsync(Categoria categoria){
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task AlterAsync(Categoria categoria){
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync (Categoria categoria){
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }
    }
}