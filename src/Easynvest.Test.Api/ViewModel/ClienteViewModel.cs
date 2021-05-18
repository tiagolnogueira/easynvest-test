using System;
using System.ComponentModel.DataAnnotations;

namespace Easynvest.Test.Api.ViewModel
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Idade { get; set; }
        public decimal Saldo { get; set; }
    }
}
