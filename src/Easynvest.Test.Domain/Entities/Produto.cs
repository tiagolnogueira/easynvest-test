namespace Easynvest.Test.Domain.Entities
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }
        public decimal Estoque { get; set; }
        public string PrecoUnitario { get; set; }
        public int ValorMinimoDeCompra { get; set; }
    }
}
