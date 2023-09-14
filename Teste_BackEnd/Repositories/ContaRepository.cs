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

        public async Task<Conta> GetByUserAsync(string email, string senha)
        {
            return await _dbContext.Contas.FirstOrDefaultAsync(c => c.Email == email && c.Senha == senha);
        }

        public async Task<bool> VerificarSeNumeroFoiUtilizado(int num)
        {
            return await _dbContext.Contas.AnyAsync(x => x.Numero == num);
        }
    }
}
