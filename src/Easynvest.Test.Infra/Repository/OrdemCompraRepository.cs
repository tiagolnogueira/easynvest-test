using Easynvest.Test.Domain.Entities;
using Easynvest.Test.Infra.Context;
using Easynvest.Test.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easynvest.Test.Infra.Repository
{
    public class OrdemCompraRepository : Repository<OrdemCompra>, IOrdemCompraRepository
    {
        public OrdemCompraRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<OrdemCompra>> ObterOrdensPendentes()
        {
            return await Db.OrdemCompras.AsNoTracking().Where(oc => oc.Status == OrdemCompraStatus.EmAnalise).ToListAsync();
        }
    }
}
