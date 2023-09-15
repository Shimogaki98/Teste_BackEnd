using Teste_BackEnd.Models;

namespace Teste_BackEnd.Interfaces.Services
{
    public interface IContaService
    {
        Task<List<Conta>> CadastrarConta(Conta conta);
        Task<List<Conta>> Get();
        Task<Conta> GetByUserAsync(string email, string senha);
        Task<string> ObterSaldo(string email);
        Task<Conta> GetByNumero(int numero);
        Task<Conta> GetByUserIdentity(string Id);
        Task<bool> Transferir(string rem, int dest, decimal valor);
    }
}
