using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Infrastructure.Data.Repositorys
{
    public class RepositoryUnidade : RepositoryBase<Unidade>, IRepositoryUnidade
    {
        private readonly AppDbContext appDbContext;

        public RepositoryUnidade(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public override async Task<Unidade> PostAsync(Unidade obj)
        {
            return await base.PostAsync(await InsertProgressoAsync(obj));
        }

        public async Task<Unidade> InsertProgressoAsync(Unidade unidade)
        {
            List<Capitulo> capitulosConsultados = new List<Capitulo>();
            foreach (Capitulo capitulo in unidade.Capitulos)
            {
                Capitulo capituloConsultado = await appDbContext.Capitulos.FindAsync(capitulo.Id);
                capitulosConsultados.Add(capituloConsultado);
            }
            unidade.ChangeCapituloValue(capitulosConsultados);
            return unidade;
        }

        public override async Task<Unidade> PutAsync(Unidade obj)
        {
            return await base.PutAsync(await UpdateAsync(obj));
        }

        private async Task<Unidade> UpdateAsync(Unidade unidade)
        {
            Unidade consulta = await appDbContext.Unidades
                                    .Include(x => x.Capitulos)
                                    .ThenInclude(x => x.Progressos)
                                    .FirstAsync(x => x.Id == unidade.Id);
            if (consulta == null)
                return null;

            await PopulateProgresso(unidade, consulta);
            return consulta;
        }

        private async Task PopulateProgresso(Unidade unidade, Unidade consulta)
        {
            consulta.Capitulos.Clear();
            foreach (Capitulo capitulo in unidade.Capitulos)
            {
                Capitulo capituloConsultado = await appDbContext.Capitulos.FindAsync(capitulo.Id);
                consulta.Capitulos.Add(capituloConsultado);
            }
        }

        public async Task<Unidade> GetByIdDetalhesAsync(long id)
        {
            Unidade obj = await appDbContext.Unidades
                .Include(x => x.Capitulos)
                .ThenInclude(x => x.Progressos)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return obj;
        }
    }
}
