using Easynvest.Test.Domain.Entities;
using Easynvest.Test.Infra.Context;
using Easynvest.Test.Infra.Interfaces;

namespace Easynvest.Test.Infra.Repository
{
    public class ClienteRepository: Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(MeuDbContext context) : base(context) { }
    }
}
