using Easynvest.Test.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Easynvest.Test.Api.ViewModel
{
    public class OrdemCompraViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DataOperacao { get; set; }
        public int ProdutoId { get; set; }
        public string ClienteId { get; set; }
        public int QuantidadeSolicitada { get; set; }
        public decimal ValorOperacao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public OrdemCompraStatus Status { get; set; }
    }
}
