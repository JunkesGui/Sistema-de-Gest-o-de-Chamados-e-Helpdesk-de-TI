using HelpDesk.API.Models.Entities;
using HelpDesk.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadosController : ControllerBase
    {
        private readonly ChamadosService _service;

        public ChamadosController(ChamadosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] StatusEnum? status,
            [FromQuery] PrioridadeEnum? prioridade,
            [FromQuery] int? categoriaId)
        {
            return Ok(await _service.GetAll(status, prioridade, categoriaId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _service.GetOne(id));
        }

        [HttpPost]
        public async Task<IActionResult> StartChamado(Chamado chamado)
        {
            var criado = await _service.StartChamado(chamado);
            return CreatedAtAction(nameof(GetOne), new { id = criado.Id }, criado);
        }

        [Authorize]
        [HttpPost("{id}/iniciar")]
        public async Task<IActionResult> AttendtoChamado(int id)
        {
            return Ok(await _service.AttendtoChamado(id));
        }

        [Authorize]
        [HttpPost("{id}/encerrar")]
        // public async Task<IActionResult> Encerrar(int id, EncerrarChamadoDto dto)
        // {
        //     return Ok(await _service.EncerrarChamado(id, dto.Solucao));
        // }

        [HttpPost("{id}/interacoes")]
        public async Task<IActionResult> AddInteraction(int id, Interacao interacao)
        {
            var criada = await _service.AddInteraction(id, interacao);
            return CreatedAtAction(nameof(GetOne), new { id }, criada);
        }
    }
}
