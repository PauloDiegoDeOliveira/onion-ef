using AutoMapper;
using Empresa.Projeto.Application.Dtos.Usuario;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using Empresa.Projeto.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Empresa.Projeto.Application
{
    public class ApplicationUsuario :
        ApplicationBase<Usuario, ViewUsuarioDto, PostUsuarioDto, PutUsuarioDto>,
        IApplicationUsuario
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
            ConverteSenhaEmHash(obj);
            return base.PostAsync(obj);
        }

        public override Task<ViewUsuarioDto> PutAsync(PutUsuarioDto obj)
        {
            ConverteSenhaEmHash(obj);
            return base.PutAsync(obj);
        }

        private void ConverteSenhaEmHash(PostUsuarioDto post)
        {
            var passwordHasher = new PasswordHasher<PostUsuarioDto>();
            post.Senha = passwordHasher.HashPassword(post, post.Senha);
        }

        private void ConverteSenhaEmHash(PutUsuarioDto put)
        {
            var passwordHasher = new PasswordHasher<PutUsuarioDto>();
            put.Senha = passwordHasher.HashPassword(put, put.Senha);
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
            {
                return null;
            }

            //await usuarioRepository.UltimoAcessoAsync(usuarioConsultado);

            if (await ValidaEAtualizaHashAsync(viewPreAutenticacao, consulta.Senha))
            {
                ViewAposAutenticacaoDto usuarioLogado = mapper.Map<ViewAposAutenticacaoDto>(consulta);

                usuarioLogado.Token.Token = serviceJWT.GerarToken(consulta);
                usuarioLogado.Token.Mensagem = "Usuário autenticado com sucesso!";
                usuarioLogado.Token.TokenExpira = DateTime.Now.AddMinutes(Convert.ToInt32(configuration.GetSection("JWT:ExpiraEmMinutos").Value)).ToString();
                return usuarioLogado;
            }
            return null;
        }

        private static async Task<bool> ValidaEAtualizaHashAsync(ViewPreAutenticacaoDto viewAutenticacao, string hash)
        {
            await Task.CompletedTask;
            var passwordHasher = new PasswordHasher<ViewPreAutenticacaoDto>();
            var status = passwordHasher.VerifyHashedPassword(viewAutenticacao, hash, viewAutenticacao.Senha);
            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;

                case PasswordVerificationResult.Success:
                    return true;

                case PasswordVerificationResult.SuccessRehashNeeded:
                    return true;

                default:
                    throw new InvalidOperationException();
            }
        }

        public async Task<ViewUsuarioDto> PutStatusAsync(long id, Status status)
        {
            Usuario consulta = await serviceUsuario.GetByIdUsuarioAsync(id);
            if (consulta is null)
            {
                return null;
            }

            consulta.ChangeStatusValue((int)status);
            consulta.ChangeAlteradoEmValue(DateTime.Now);

            Usuario obj = await serviceUsuario.PutStatusAsync(consulta);
            return mapper.Map<ViewUsuarioDto>(obj);
        }

        public async Task<ViewUsuarioPermissaoDto> GetByIdDetalhesAsync(long id)
        {
            Usuario consulta = await serviceUsuario.GetByIdDetalhesAsync(id);               
            return mapper.Map<ViewUsuarioPermissaoDto>(consulta);
        }
    }
}