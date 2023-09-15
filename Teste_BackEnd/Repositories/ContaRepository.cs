using Teste_BackEnd.Data;
using Teste_BackEnd.Interfaces.Repository;
using Teste_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace Teste_BackEnd.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly DataContext _dbContext;

        public ContaRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Conta>> CadastrarContaAsync(Conta conta)
        {
            _dbContext.Add(conta);
            await _dbContext.SaveChangesAsync();
            return await GetAsync();
        }

        public async Task<List<Conta>> GetAsync()
        {
            return await _dbContext.Contas.ToListAsync();
        }

        public async Task<Conta> GetByNumero(int numero)
        {
            return await _dbContext.Contas.FirstOrDefaultAsync(c => c.Numero == numero);
        }

        public async Task<Conta> GetByUserAsync(string email, string senha)
        {
            return await _dbContext.Contas.FirstOrDefaultAsync(c => c.Email == email && c.Senha == senha);
        }

        public async Task<Conta> GetByUserIdentity(string Id)
        {
            return await _dbContext.Contas.FirstOrDefaultAsync(c => c.Email == Id);
        }

        public async Task<string> ObterSaldo(string email)
        {
            var saldo = await _dbContext.Contas.Where(c => c.Email == email).Select(c => c.Saldo).FirstOrDefaultAsync();
            return saldo.ToString();
        }

        public async Task<bool> VerificarSeNumeroFoiUtilizado(int num)
        {
            return await _dbContext.Contas.AnyAsync(x => x.Numero == num);
        }

        public async Task RegistrarTransacao(int entrada, int saida, decimal valor)
        {
            var contaEntrada = new Transacao("Entrada", valor, entrada);
            var contaSaida = new Transacao("Saída", valor, saida);

            _dbContext.Transacoes.Add(contaEntrada);
            _dbContext.Transacoes.Add(contaSaida);

            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
