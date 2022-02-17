namespace Empresa.Projeto.Domain.Entitys
{
    public class ClienteForm : UploadFormBase
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        protected ClienteForm()
        { }

        public ClienteForm(string nome,
                       string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
    }
}