using Empresa.Projeto.Domain.Enums;
using System.IO;

namespace Empresa.Projeto.Application.Utilities
{
    internal class PathCreator
    {
        public string CreateAbsolutePath(string pathRecived)
        {
            DateInformations dateInformations = new DateInformations();

            string path = pathRecived + $@"\" + dateInformations.GetSplitData(Date.Year) + 
                $@"\" + dateInformations.GetSplitData(Date.Month) + 
                $@"\" + dateInformations.GetSplitData(Date.Day) + $@"\";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        public string CreateRelativePath(string pathRecived)
        {
            DateInformations dateInformations = new DateInformations();

            string path = pathRecived + "/" + dateInformations.GetSplitData(Date.Year) +
                $@"/" + dateInformations.GetSplitData(Date.Month) +
                $@"/" + dateInformations.GetSplitData(Date.Day) + $@"/";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}