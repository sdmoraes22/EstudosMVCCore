using CMSOFT.AppModelo.Models;
using Microsoft.EntityFrameworkCore;

namespace CMSOFT.AppModelo.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options)
            : base(options)
        {
            
        }
 
        public DbSet<Aluno> Alunos { get; set; }
    }
}