using AmbevConexao.Data.Map;
using AmbevConexao.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AmbevConexao.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<TurmaAluno> TurmaAluno { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=LAPTOP-GPMPQN74\\MSSQLSERVER02; Database=Minha1ConexaoAmbev; " +
                "Trusted_Connection=True; TrustServerCertificate=True")
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);            

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new TurmaAlunoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
