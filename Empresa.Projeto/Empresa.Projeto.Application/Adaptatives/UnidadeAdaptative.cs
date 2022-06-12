using Empresa.Projeto.Application.Dtos.Capitulo;
using Empresa.Projeto.Application.Dtos.Unidade;
using Empresa.Projeto.Domain.Enums;
using System.Collections.Generic;


namespace Empresa.Projeto.Application.Adaptatives
{
    public class UnidadeAdaptative
    {
        public int Id { get; set; }
        public int NumeroUnidade { get; set; }
        public Status Status { get; set; }
        public List<CapituloAdaptative> Capitulos { get; set; }

        public void Construtor(ViewUnidadeDto viewUnidadeDto)
        {
            Id = viewUnidadeDto.Id;
            NumeroUnidade = viewUnidadeDto.NumeroUnidade;
            Status = viewUnidadeDto.Status;
            Capitulos = AdaptadorCapitulo(viewUnidadeDto.Capitulos);
        }

        private List<CapituloAdaptative> AdaptadorCapitulo(List<ViewCapituloDto> viewCapitulos)
        {
            List<CapituloAdaptative> capituloAdaptative = new List<CapituloAdaptative>();
            foreach (var itemCapitulo in viewCapitulos)
            {
                CapituloAdaptative viewCapituloAdaptative = new CapituloAdaptative();
                viewCapituloAdaptative.Construtor(itemCapitulo);

                capituloAdaptative.Add(viewCapituloAdaptative);
            }
            return capituloAdaptative;
        }
    }
}
