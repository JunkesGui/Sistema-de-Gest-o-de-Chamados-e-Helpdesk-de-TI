using HelpDesk.API.Models.Entities;
using HelpDesk.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.API.Repositories
{
    public class ChamadosRepository
    {
        private readonly AppDbContext _context;

        public ChamadosRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<Chamado?> GetOneAsync(int id)
        {
            return await _context.Chamados.FindAsync(id);
        }

        public async Task<Chamado?> GetOneWithDetailsAsync(int id)
        {
            return await _context.Chamados
                .AsNoTracking()
                .Include(c => c.Categoria)
                .Include(c => c.Interacoes.OrderBy(i => i.DataRegistro))
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Chamado>> GetAllAsync(StatusEnum? status, PrioridadeEnum? prioridade, int? categoriaId)
        {
            var query = _context.Chamados.AsNoTracking().Include(c => c.Categoria).AsQueryable();

            if (status.HasValue)
                query = query.Where(c => c.Status == status.Value);

            if (prioridade.HasValue)
                query = query.Where(c => c.Prioridade == prioridade.Value);

            if (categoriaId.HasValue)
                query = query.Where(c => c.CategoriaId == categoriaId.Value);

            return await query.OrderByDescending(c => c.DataAbertura).ToListAsync();
        }

        public async Task CreateAsync(Chamado chamado)
        {
            await _context.Chamados.AddAsync(chamado);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Chamado chamado)
        {
            _context.Chamados.Update(chamado);
            await _context.SaveChangesAsync();
        }
    }
}
