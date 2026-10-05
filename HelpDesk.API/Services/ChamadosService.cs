using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.API.Models.Entities;
using HelpDesk.API.Repositories;

namespace HelpDesk.API.Services
{
    public class ChamadosService
    {
        private readonly ChamadosRepository _cRepository;
        private readonly InteracoesRepository _iRepository;

        public ChamadosService(
            ChamadosRepository cRepository,
            InteracoesRepository iRepository){
                _cRepository = cRepository;
                _iRepository = iRepository;
            }
        
        public async Task StartChamado(Chamado chamado){
            chamado.Status = StatusEnum.Aberto;
            chamado.DataAbertura = DateTime.Now;

            await _cRepository.CreateAsync(chamado);

            var interacao = new Interacao{
                ChamadoId = chamado.Id,
                DataRegistro = DateTime.Now,
                Mensagem = "Chamado Aberto",
                Autor = "Admin"
            };

            await _iRepository.CreateAsync(interacao);
        }

        public async Task<Chamado> GetOne(int id){
            return await _cRepository.GetOneAsync(id);
        }

        public async Task AttendtoChamado(int id){
            Chamado chamado = await _cRepository.GetOneAsync(id);
            chamado.Status = StatusEnum.EmAndamento;
            await _cRepository.UpdateAsync(chamado);
        }

        public async Task AddInteraction(int id, Interacao interacao){
            Chamado chamado = await _cRepository.GetOneAsync(id);

            if(chamado.Status == StatusEnum.Fechado){
                throw new Exception("Não é possível adicionar interações em chamados fechados.");
            }

            interacao.ChamadoId = id;
            interacao.DataRegistro = DateTime.Now;

            await _iRepository.CreateAsync(interacao);
        }

    }
}