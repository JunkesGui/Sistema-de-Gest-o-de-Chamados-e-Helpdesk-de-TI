using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using HelpDesk.API.Models.Entities;
using HelpDesk.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadosController : ControllerBase{
        private readonly ChamadosService _service;

        public ChamadosController(ChamadosService service){
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id){
            Chamado chamado = await _service.GetOne(id);
            return Ok(chamado);
        }
        
        [HttpPost]
        public async Task<IActionResult> StartChamado(Chamado chamado){
            await _service.StartChamado(chamado);
            return Created(" ", chamado);
        }

        [HttpPut("{id}/inicar")]
        public async Task<IActionResult> AttendtoChamado(int id){
            await _service.AttendtoChamado(id);
            return Ok();
        }

        [HttpPost("{id}/interacoes")]
        public async Task<IActionResult> AddInteraction(int id, Interacao interacao){
            await _service.AddInteraction(id, interacao);
            return Created(" ", interacao);
        }

    }
}