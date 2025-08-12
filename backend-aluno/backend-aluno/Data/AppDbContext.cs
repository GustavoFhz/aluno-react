using backend_aluno.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_aluno.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<AlunoModel> Alunos { get; set; }
    }
    
    
}
