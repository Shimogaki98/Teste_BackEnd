using System.ComponentModel.DataAnnotations;

namespace Teste_BackEnd.Models
{
    public class Transacao
    {
        [Key]
        public int Id { get; set; }
        public int Conta { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;

        public Transacao(string tipo, decimal valor, int conta)
        {
            Conta = conta;
            Tipo = tipo;
            Valor = valor;
            Data = DateTime.Now;
        }
    }
}
