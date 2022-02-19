using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly AppDbContext appDbContext;

        public RepositoryUsuario(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public override async Task<Usuario> PostAsync(Usuario obj)
        {
            return await base.PostAsync(await InsertEspecialidadesAsync(obj));
        }

        public async Task<Usuario> InsertEspecialidadesAsync(Usuario usuario)
        {
            List<Especialidade> especialidadesConsultadas = new List<Especialidade>();
            foreach (Especialidade especialidade in usuario.Especialidades)
            {
                Especialidade especialidadeConsultada = await appDbContext.Especialidades.FindAsync(especialidade.Id);
                especialidadesConsultadas.Add(especialidadeConsultada);
            }
            usuario.ChangeEspecialidadesValue(especialidadesConsultadas);
            return usuario;
        }

        public override async Task<Usuario> PutAsync(Usuario obj)
        {
            return await base.PutAsync(await UpdateAsync(obj));
        }

        private async Task<Usuario> UpdateAsync(Usuario usuario) 
        {
            Usuario consulta = await appDbContext.Usuarios
                                    .Include(x => x.Especialidades)
                                    .FirstAsync(x => x.Id == usuario.Id);
            if (consulta == null)
                return null;

            await PopulateEspecialidades(usuario, consulta); 
            return consulta;
        }

        private async Task PopulateEspecialidades(Usuario usuario, Usuario consulta)
        {
            consulta.Especialidades.Clear();
            foreach (Especialidade especialidade in usuario.Especialidades)
            {
                Especialidade especialidadeConsultada = await appDbContext.Especialidades.FindAsync(especialidade.Id);
                consulta.Especialidades.Add(especialidadeConsultada);
            }
        }

        public async Task<Usuario> PutUltimoAcessoAsync(Usuario obj)
        {
            Usuario result = await UpdateAsync(obj);
            result.ChangeUltimoAcessoEmValue(DateTime.Now);
            return await base.PutAsync(result);
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
                                   .Include(x => x.Especialidades)
                                   .Where(x => x.Email.ToLower() == email.ToLower())
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync();
            return obj;
        }

        public async Task<Usuario> GetByIdDetalhesAsync(long id)
        {
            Usuario obj = await appDbContext.Usuarios
                .Include(x => x.Permissao)
                .Include(x => x.Especialidades)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return obj;
        }
    }
}