using System;

namespace Easynvest.Test.Domain.Entities
{
    public class OrdemCompra : Entity
    {
        public OrdemCompra()
        {
            Status = OrdemCompraStatus.Solicitado;
        }

        public DateTime DataOperacao { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid ClienteId { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public decimal ValorOperacao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public OrdemCompraStatus Status { get; set; }
    }
}
