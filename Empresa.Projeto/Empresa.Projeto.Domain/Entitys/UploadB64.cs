using System;

namespace Empresa.Projeto.Domain.Entitys
{
    public class UploadB64 : EntityBase
    {
        public Guid IdGuid { get; private set; }

        public string CaminhoRelativo { get; private set; }
        public string CaminhoAbsoluto { get; private set; }

        protected UploadB64()
        { }

        protected UploadB64(Guid idGuid, string caminhoRelativo, string caminhoAbsoluto)
        {
            IdGuid = idGuid;
            CaminhoRelativo = caminhoRelativo;
            CaminhoAbsoluto = caminhoAbsoluto;
        }

        public void PolulateInformations(string caminhoRelativo, string caminhoAbsoluto)
        {
            IdGuid = Guid.NewGuid();
            CaminhoRelativo = caminhoRelativo + IdGuid + ".jpg";
            CaminhoAbsoluto = caminhoAbsoluto + IdGuid + ".jpg";
        }
    }
}
