using Easynvest.Test.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easynvest.Test.Infra.Interfaces
{
    public interface IOrdemCompraRepository : IRepository<OrdemCompra>
    {
        Task<IEnumerable<OrdemCompra>> ObterOrdensPendentes();
    }
}
