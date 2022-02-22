using Microsoft.AspNetCore.Http;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Empresa.Projeto.Application.Dtos.UploadForm
{
    public class ViewUploadFormDto
    {
        public long Id { get; set; }

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