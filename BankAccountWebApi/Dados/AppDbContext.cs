using BankAccountWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAccountWebApi.Dados
{
    public class AppDbContext : DbContext
    {
        DbSet<ContaCorrente> ContaCorrenteBanco { get; set; }
        DbSet<Correntista>  CorrentistasBanco { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) 
        { 

        } 
    }
}
