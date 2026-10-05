using HelpDesk.API.Data;
using HelpDesk.API.Models.Entities;

namespace HelpDesk.API.Repositories
{
    public class InteracoesRepository
    {
        private readonly AppDbContext _context;

        public InteracoesRepository(AppDbContext context){
            _context = context;
        }

        public async Task CreateAsync(Interacao interacao){
            await _context.Interacoes.AddAsync(interacao);
            await _context.SaveChangesAsync();
        }
    }
}