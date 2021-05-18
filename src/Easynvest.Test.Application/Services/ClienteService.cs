using Easynvest.Test.Application.Interfaces;
using Easynvest.Test.Infra.Interfaces;

namespace Easynvest.Test.Application.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository,
                              INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
