using System.ComponentModel.DataAnnotations;

namespace Teste_BackEnd.Models
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        public string Nome { get; set; }

        [MaxLength(40)]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
        public int Numero { get; set; }
        public int Saldo { get; set; }

        public Conta(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }


}
