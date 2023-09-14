using Microsoft.EntityFrameworkCore;
using Teste_BackEnd.Models;

namespace Teste_BackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Conta> Contas { get; set; }
    }
}
