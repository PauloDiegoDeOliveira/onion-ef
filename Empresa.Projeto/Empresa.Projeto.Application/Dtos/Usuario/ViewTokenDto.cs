namespace Empresa.Projeto.Application.Dtos.Usuario
{
    public class ViewTokenDto
    {
        public string Token { get; set; }
        public string TokenExpira { get; set; }
        public string Mensagem { get; set; }

        public void PopulateValidToken(string token, string message, string expiredTime)
        {
            Token = token;
            Mensagem = message;
            TokenExpira = expiredTime;
        }
    }
}