using Microsoft.EntityFrameworkCore;
using HelpDesk.API.Models.Entities;
using HelpDesk.API.Data;

namespace HelpDesk.API.Repositories
{
    public class ChamadosRepository
    {
        private readonly AppDbContext _context;

        public ChamadosRepository(AppDbContext context){
            _context = context;
        }

        public async Task<Chamado> GetOneAsync(string id){
            return await _context.Chamados.FindAsync(id);
        }

        public async Task CreateAsync(Chamado chamado){
            await _context.Chamados.AddAsync(chamado);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Chamado> GetQueryable()
        {
            return _context.Chamados.AsQueryable();
        }
    }
}