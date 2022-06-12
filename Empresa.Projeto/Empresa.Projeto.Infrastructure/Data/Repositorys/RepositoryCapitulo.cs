using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryCapitulo : RepositoryBase<Capitulo>, IRepositoryCapitulo
    {
        private readonly AppDbContext appDbContext;

        public RepositoryCapitulo(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public override async Task<Capitulo> PostAsync(Capitulo obj)
        {
            return await base.PostAsync(await InsertProgressoAsync(obj));
        }

        public async Task<Capitulo> InsertProgressoAsync(Capitulo capitulo)
        {
            List<Progresso> progressoConsultados = new List<Progresso>();
            foreach (Progresso progresso in capitulo.Progressos)
            {
                Progresso progressoConsultado = await appDbContext.Progressos.FindAsync(progresso.Id);
                progressoConsultados.Add(progressoConsultado);
            }
            capitulo.ChangeProgressoValue(progressoConsultados);
            return capitulo;
        }

        public override async Task<Capitulo> PutAsync(Capitulo obj)
        {
            return await base.PutAsync(await UpdateAsync(obj));
        }

        private async Task<Capitulo> UpdateAsync(Capitulo capitulo)
        {
            Capitulo consulta = await appDbContext.Capitulos
                                    .Include(x => x.Progressos)
                                    .FirstAsync(x => x.Id == capitulo.Id);
            if (consulta == null)
                return null;

            await PopulateProgresso(capitulo, consulta);
            return consulta;
        }

        private async Task PopulateProgresso(Capitulo capitulo, Capitulo consulta)
        {
            consulta.Progressos.Clear();
            foreach (Progresso progresso in capitulo.Progressos)
            {
                Progresso progressoConsultado = await appDbContext.Progressos.FindAsync(progresso.Id);
                consulta.Progressos.Add(progressoConsultado);
            }
        }

        public async Task<Capitulo> GetByIdDetalhesAsync(long id)
        {
            Capitulo obj = await appDbContext.Capitulos
                .Include(x => x.Progressos)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return obj;
        }
    }
}
