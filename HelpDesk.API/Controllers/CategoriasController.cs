using HelpDesk.API.Models.Entities;
using HelpDesk.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase{
        private readonly CategoriasService _service;

        public CategoriasController(CategoriasService service){
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            List<Categoria> categorias = await _service.Getall();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id){
            Categoria categoria = await _service.GetOne(id);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria){
            await _service.Create(categoria);
            return Created(" ", categoria);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            await _service.Delete(id);
            return Ok("Categoria deletada com sucesso!");
        }

    }
}