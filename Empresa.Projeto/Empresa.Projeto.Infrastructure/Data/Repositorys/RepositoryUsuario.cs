using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly AppDbContext appDbContext;

        public RepositoryUsuario(AppDbContext appContext) : base(appContext)
        {
            this.appDbContext = appContext;
        }

        public async Task<IList<Usuario>> GetNomeAsync(string nome)
        {
            var obj = await appDbContext.Usuarios
                                        .Where(ns => EF.Functions.Like(ns.Nome, $"%{nome}%"))
                                        .AsNoTracking()
                                        .ToListAsync();
            return obj;
        }

        public async Task<Usuario> GetEmailAsync(string email) 
        {
            var obj = await appDbContext.Usuarios
                                   .Where(x => x.Email.ToLower() == email.ToLower())
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync();
            return obj;
        }
    }
}