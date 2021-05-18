using AutoMapper;
using Easynvest.Test.Api.ViewModel;
using Easynvest.Test.Application.Interfaces;
using Easynvest.Test.Domain.Entities;
using Easynvest.Test.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Easynvest.Test.Api.Controllers
{
    [Route("api/ordemcompra")]
    public class OrdemCompraController : MainController
    {
        private readonly IOrdemCompraRepository _ordemCompraRepository;
        private readonly IOrdemCompraService _ordemCompraService;
        private readonly IMapper _mapper;

        public OrdemCompraController(INotificador notificador,
                                  IOrdemCompraRepository ordemCompraRepository,
                                  IOrdemCompraService ordemCompraService,
                                  IMapper mapper) : base(notificador)
        {
            _ordemCompraRepository = ordemCompraRepository;
            _ordemCompraService = ordemCompraService;
            _mapper = mapper;
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrdemCompraViewModel>> ObterPorId(Guid id)
        {
            var ordemCompra = _mapper.Map<OrdemCompraViewModel>(await _ordemCompraRepository.ObterPorId(id));

            if (ordemCompra == null) return NotFound();

            return ordemCompra;
        }

        [HttpPost]
        public async Task<ActionResult<OrdemCompraViewModel>> Adicionar(OrdemCompraViewModel ordemCompraViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _ordemCompraService.RegistrarOrdemCompra(_mapper.Map<OrdemCompra>(ordemCompraViewModel));

            return CustomResponse(ordemCompraViewModel);
        }

        [HttpPost("adicionar-ordem-pendente")]
        public async Task<IActionResult> AtualizarOrdem(OrdemCompraViewModel ordemCompraViewModel)
        {
            
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var ordemCompraId = await _ordemCompraService.RegistrarOrdemCompra(_mapper.Map<OrdemCompra>(ordemCompraViewModel));

            await _ordemCompraService.AlterarStatudOrdemDeCompraParaEmAnalise(ordemCompraId);

            return CustomResponse(ordemCompraViewModel);
        }

        [HttpPost("enviar-ordes-pendente")]
        public async Task<IActionResult> EnviarOrdesPendentes()
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var ordensPendentes = await _ordemCompraService.EnviarOrdensPendentes();

            return CustomResponse(ordensPendentes);
        }
    }
}
