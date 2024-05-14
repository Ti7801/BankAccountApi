using BankAccountWebApi.Models;
using Microsoft.EntityFrameworkCore;


namespace BankAccountWebApi.Dados
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContaCorrente> ContaCorrenteBanco { get; set; }
        public DbSet<Correntista> CorrentistasBanco { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) 
        { 
           
        } 
    }
}
