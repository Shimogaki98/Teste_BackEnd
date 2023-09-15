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

        public async Task<Conta> GetByNumero(int numero)
        {
            return await _contaRepository.GetByNumero(numero);
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

        public async Task<bool> Transferir(string rem, int dest, decimal valor)
        {
            var remetente = await _contaRepository.GetByUserIdentity(rem);
            var destinatario = await _contaRepository.GetByNumero(dest);

            bool contasValidas = await ValidarContas(remetente, destinatario, valor);

            if (contasValidas)
            {
                remetente.Saldo -= valor;
                destinatario.Saldo += valor;

                await _contaRepository.RegistrarTransacao(dest, remetente.Numero, valor);
            }

            // buscar a conta remetente e criar validacoes, verificar se a conta destinatária existe

            return true;
        }

        private async Task<bool> ValidarContas(Conta remetente, Conta destinatario, decimal valor)
        {
            if (destinatario == null || remetente == null)
                throw new Exception("Erro ao buscar contas");

            if (remetente.Saldo < valor)
                throw new Exception("Saldo insuficiente para realizar transação");

            return true;
        }

        public async Task<Conta> GetByUserIdentity(string Id)
        {
            return await _contaRepository.GetByUserIdentity(Id);
        }

        public async Task<List<Transacao>> GetExtratoAsync(int id)
        {
            return await _contaRepository.GetExtratoAsync(id);
        }
    }
}
