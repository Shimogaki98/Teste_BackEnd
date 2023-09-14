using Teste_BackEnd.Models;

namespace Teste_BackEnd.Interfaces.Services
{
    public interface IContaService
    {
        Task<List<Conta>> CadastrarConta(Conta conta);
        Task<List<Conta>> Get();
        Task<Conta> GetByUserAsync(string email, string senha);
    }
}
