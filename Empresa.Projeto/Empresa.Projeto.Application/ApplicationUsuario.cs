using AutoMapper;
using Empresa.Projeto.Application.Dtos.Usuario;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Empresa.Projeto.Application.Utilities;

namespace Empresa.Projeto.Application
{
    public class ApplicationUsuario : ApplicationBase<Usuario, ViewUsuarioDto, PostUsuarioDto, PutUsuarioDto>, IApplicationUsuario
    {
        private readonly IServiceUsuario serviceUsuario;
        private readonly IConfiguration configuration;
        private readonly IServiceJWT serviceJWT;

        public ApplicationUsuario(IServiceUsuario serviceUsuario,
                                         IMapper mapper,
                                         IConfiguration configuration,
                                         IServiceJWT serviceJWT) : base(serviceUsuario, mapper)
        {
            this.serviceUsuario = serviceUsuario;
            this.configuration = configuration;
            this.serviceJWT = serviceJWT;
        }

        public override Task<ViewUsuarioDto> PostAsync(PostUsuarioDto obj)
        {
            HashedPassword hashedPassword = new PasswordHasherManager().ConvertPasswordToHash(obj.Senha);
            obj.Senha = hashedPassword.Password;       
            return base.PostAsync(obj);
        }

        public override Task<ViewUsuarioDto> PutAsync(PutUsuarioDto obj)
        {
            HashedPassword hashedPassword = new PasswordHasherManager().ConvertPasswordToHash(obj.Senha);
            obj.Senha = hashedPassword.Password;
            return base.PutAsync(obj);
        }      

        public async Task<IList<ViewUsuarioDto>> GetNomeAsync(string nome)
        {
            IList<Usuario> consulta = await serviceUsuario.GetNomeAsync(nome);
            return mapper.Map<IList<ViewUsuarioDto>>(consulta);
        }

        public async Task<ViewAposAutenticacaoDto> AutenticacaoAsync(ViewPreAutenticacaoDto viewPreAutenticacao)
        {
            Usuario consulta = await serviceUsuario.GetEmailAsync(viewPreAutenticacao.Email);

            if (consulta is null)
                return null;

            await serviceUsuario.PutUltimoAcessoAsync(consulta);

            if (await new PasswordHasherManager().ValidatePassword(consulta.Senha, viewPreAutenticacao.Senha))
            {
                ViewAposAutenticacaoDto usuarioLogado = mapper.Map<ViewAposAutenticacaoDto>(consulta);

                usuarioLogado.Token.PopulateValidToken(serviceJWT.GerarToken(consulta),
                    "Usuário autenticado com sucesso!",
                    DateTime.Now.AddMinutes(Convert.ToInt32(configuration.GetSection("JWT:ExpiraEmMinutos").Value)).ToString());
                
                return usuarioLogado;
            }

            return null;
        }

        public async Task<ViewUsuarioPermissaoDto> GetByIdDetalhesAsync(long id)
        {
            Usuario consulta = await serviceUsuario.GetByIdDetalhesAsync(id);
            return mapper.Map<ViewUsuarioPermissaoDto>(consulta);
        }
    }
}