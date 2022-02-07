using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace Empresa.Projeto.Domain.Entitys
{
    public class UploadForm : EntityBase
    {
        [NotMapped]
        public IFormFile ImagemUpload { get; private set; }

        public Guid IdGuid { get; private set; }
        public long TamanhoEmBytes { get; private set; }
        public string ContentType { get; private set; }
        public string ExtensaoArquivo { get; private set; }
        public string NomeArquivoOriginal { get; private set; }
        public string CaminhoRelativo { get; private set; }
        public string CaminhoAbsoluto { get; private set; }

        protected UploadForm()
        { }

        public UploadForm(IFormFile imageUpload,
                            Guid idGuid,
                            long tamanhoEmBytes,
                            string contentType,
                            string extensaoArquivo,
                            string nomeArquivoOriginal,
                            string caminhoRelativo,
                            string caminhoAbsoluto)
        {
            ImagemUpload = imageUpload;
            IdGuid = idGuid;
            TamanhoEmBytes = tamanhoEmBytes;
            ContentType = contentType;
            ExtensaoArquivo = extensaoArquivo;
            NomeArquivoOriginal = nomeArquivoOriginal;
            CaminhoRelativo = caminhoRelativo;
            CaminhoAbsoluto = caminhoAbsoluto;
        }

        public void PolulateInformations(UploadForm uploadForm, string caminhoRelativo, string caminhoAbsoluto)
        {
            IdGuid = Guid.NewGuid();
            ImagemUpload = uploadForm.ImagemUpload;
            TamanhoEmBytes = uploadForm.ImagemUpload.Length;
            ContentType = uploadForm.ImagemUpload.ContentType;
            ExtensaoArquivo = Path.GetExtension(uploadForm.ImagemUpload.FileName);
            NomeArquivoOriginal = Path.GetFileNameWithoutExtension(uploadForm.ImagemUpload.FileName);
            CaminhoRelativo = caminhoRelativo + IdGuid + "_" + ImagemUpload.FileName;
            CaminhoAbsoluto = caminhoAbsoluto + IdGuid + "_" + ImagemUpload.FileName;
        }
    }
}