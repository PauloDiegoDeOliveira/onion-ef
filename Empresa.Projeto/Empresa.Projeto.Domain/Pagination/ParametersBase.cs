using Empresa.Projeto.Domain.Enums;

namespace Empresa.Projeto.Domain.Pagination
{
    public class ParametersBase
    {

        public long Id { get; set; }
        public string PalavraChave { get; set; }
        public Status Status { get; set; } = Status.Ativo;

        private const int tamanhoMaximoResultados = 50;
        private int resultadosExibidos = 10;
        private int numeroPagina = 1;

        public int NumeroPagina
        {
            get
            {
                return numeroPagina;
            }
            set 
            {
                numeroPagina = (value <= 0) ? value = numeroPagina : value;
            }
        }

        public int ResultadosExibidos
        {
            get
            {
                return resultadosExibidos;
            }
            set
            {
                resultadosExibidos = (value <= 0) ? value = tamanhoMaximoResultados : (value > tamanhoMaximoResultados) ? tamanhoMaximoResultados : value;
            }
        }
    }
}
