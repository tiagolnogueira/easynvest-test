using System;
using System.ComponentModel.DataAnnotations;

namespace Easynvest.Test.Api.ViewModel
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Estoque { get; set; }
        public string PrecoUnitario { get; set; }
        public int ValorMinimoDeCompra { get; set; }
    }
}
