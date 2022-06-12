using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Dtos.AlunoB64
{
    public class PutAlunoB64Dto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string ImagemEmBase64 { get; set; }
    }
}
