using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infrastructure.Data
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CriadoEm") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CriadoEm").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CriadoEm").IsModified = false;
                }               
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}