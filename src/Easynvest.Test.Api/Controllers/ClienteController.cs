using AutoMapper;
using Easynvest.Test.Api.ViewModel;
using Easynvest.Test.Application.Interfaces;
using Easynvest.Test.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easynvest.Test.Api.Controllers
{
    [Route("api/clientes")]
    public class ClienteController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(INotificador notificador,
                                  IClienteRepository clienteRepository,
                                  IClienteService clienteService,
                                  IMapper mapper) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteViewModel>> Get()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClienteViewModel>> ObterPorId(Guid id)
        {
            var clienteViewModel = await ObterCliente(id);

            if (clienteViewModel == null) return NotFound();

            return clienteViewModel;
        }

        private async Task<ClienteViewModel> ObterCliente(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));
        }
    }
}
