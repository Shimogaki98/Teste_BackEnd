using Teste_BackEnd.Models;

namespace Teste_BackEnd.Interfaces.Repository
{
    public interface IContaRepository
    {
        Task<List<Conta>> CadastrarContaAsync(Conta conta);
        Task<List<Conta>> GetAsync();
        Task<bool> VerificarSeNumeroFoiUtilizado(int num);
    }
}
