using Easynvest.Test.Domain.Entities;
using Easynvest.Test.Infra.Context;
using Easynvest.Test.Infra.Interfaces;

namespace Easynvest.Test.Infra.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) : base(context) { }
    }
}
