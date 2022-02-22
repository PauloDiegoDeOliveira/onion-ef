using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<UploadForm> UploadForm { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<UploadB64> UploadB64 { get; set; }
        public DbSet<Progresso> Progressos { get; set; }
        public DbSet<Capitulo> Capitulos { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<ClienteForm> ClientesForm { get; set; }
        public DbSet<AlunoB64> AlunosB64 { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        //Migration
        public AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=HENRIQUENOTE;Initial Catalog=APIREST;Integrated Security=SSPI;");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CriadoEm") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CriadoEm").CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("CriadoEm").IsModified = false;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}