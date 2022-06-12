using Microsoft.AspNetCore.Http;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Empresa.Projeto.Application.Dtos.ClienteForm
{
    public class ViewClienteFormDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public IFormFile ImagemUpload { get; set; }

        public Guid IdGuid { get; set; }
        public long TamanhoEmBytes { get; set; }
        public string ContentType { get; set; }
        public string ExtensaoArquivo { get; set; }
        public string NomeArquivoOriginal { get; set; }
        public string CaminhoRelativo { get; set; }
    }
}
