using Easynvest.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easynvest.Test.Application.Interfaces
{
    public interface IOrdemCompraService
    {
        Task<bool> AlterarStatudOrdemDeCompraParaEmAnalise(Guid ordemDeCompraId);
        Task<Guid> RegistrarOrdemCompra(OrdemCompra ordemCompra);
        Task<IEnumerable<OrdemCompra>> EnviarOrdensPendentes();
    }
}
