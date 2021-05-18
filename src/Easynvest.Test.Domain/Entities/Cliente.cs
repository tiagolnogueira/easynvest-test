namespace Easynvest.Test.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Idade { get; set; }
        public decimal Saldo { get; set; }
    }
}
