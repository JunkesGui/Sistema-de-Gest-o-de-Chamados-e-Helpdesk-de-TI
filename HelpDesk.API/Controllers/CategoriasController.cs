using HelpDesk.API.Models.Entities;
using HelpDesk.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriasService _service;

        public CategoriasController(CategoriasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _service.GetOne(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            var criada = await _service.Create(categoria);
            return CreatedAtAction(nameof(GetOne), new { id = criada.Id }, criada);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Categoria categoria)
        {
            return Ok(await _service.Update(id, categoria));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
