using Teste_BackEnd.Interfaces.Repository;
using Teste_BackEnd.Interfaces.Services;
using Teste_BackEnd.Models;

namespace Teste_BackEnd.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<List<Conta>> CadastrarConta(Conta conta)
        {
            conta.Numero = await GerarNumeroConta();
            await _contaRepository.CadastrarContaAsync(conta);

            return await Get();
        }

        public async Task<List<Conta>> Get()
        {
            return await _contaRepository.GetAsync();
        }

        public async Task<Conta> GetByUserAsync(string email, string senha)
        {
            return await _contaRepository.GetByUserAsync(email, senha);
        }

        private async Task<bool> VerificarSeNumeroFoiUtilizado(int num)
        {
            return await _contaRepository.VerificarSeNumeroFoiUtilizado(num);

        }

        private async Task<int> GerarNumeroConta()
        {
            int numeroConta;
            bool numeroUtilizado = true;

            do
            {
                Random rng = new Random();
                numeroConta = rng.Next(999999);
                numeroUtilizado = await VerificarSeNumeroFoiUtilizado(numeroConta);
            }
            while (numeroUtilizado);

            return numeroConta;
        }

        public async Task<string> ObterSaldo(string email)
        {
            return await _contaRepository.ObterSaldo(email);
        }
    }
}
