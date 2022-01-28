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
            IList<Usuario> obj = await appDbContext.Usuarios
                                        .Where(x => EF.Functions.Like(x.Nome, $"%{nome}%"))
                                        .AsNoTracking()
                                        .ToListAsync();
            return obj;
        }

        public async Task<Usuario> GetEmailAsync(string email)
        {
            Usuario obj = await appDbContext.Usuarios
                                   .Where(x => x.Email.ToLower() == email.ToLower())
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync();
            return obj;
        }

        public async Task<Usuario> PutStatusAsync(Usuario usuario)
        {
            appDbContext.Usuarios.Update(usuario);
            await appDbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> GetByIdUsuarioAsync(long id)
        {
            Usuario obj = await GetByIdAsync(id);
            return obj;
        }

        public async Task<Usuario> GetByIdDetalhesAsync(long id)
        {
            Usuario obj = await appDbContext.Usuarios
                .Include(x => x.Permissao)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return obj;
        }
    }
}