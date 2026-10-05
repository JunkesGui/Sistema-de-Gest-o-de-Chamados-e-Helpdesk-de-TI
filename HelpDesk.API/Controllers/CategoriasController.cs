using HelpDesk.API.Data;
using HelpDesk.API.Models.Entities;
using HelpDesk.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase{
        private readonly CategoriasRepository _repository;

        public CategoriasController(AppDbContext context){
            _repository = new CategoriasRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            List<Categoria> categorias = await _repository.GetAllAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id){
            Categoria categoria = await _repository.GetOneAsync(id);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria){
            await _repository.CreateAsync(categoria);
            return Created(" ", categoria);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            Categoria categoria = await _repository.GetOneAsync(id);
            await _repository.DeleteAsync(categoria);
            return Ok("Categoria deletada com sucesso!");
        }

    }
}