namespace Empresa.Projeto.Domain.Entitys
{
    public class AlunoB64 : UploadB64Base
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        protected AlunoB64()
        { }

        public AlunoB64(string nome,
                       string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
    }
}
