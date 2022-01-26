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
    public class ApplicationServiceUsuario : IApplicationServiceUsuario
    {
        private readonly IServiceUsuario serviceUsuario;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IServiceJWT serviceJWT;

        public ApplicationServiceUsuario(IServiceUsuario serviceUsuario,
                                         IMapper mapper,
                                         IConfiguration configuration,
                                         IServiceJWT serviceJWT)
        {
            this.serviceUsuario = serviceUsuario;
            this.mapper = mapper;
            this.configuration = configuration;
            this.serviceJWT = serviceJWT;
        }

        public async Task<IList<ViewUsuarioDto>> GetAllAsync()
        {
            IList<Usuario> consulta = await serviceUsuario.GetAllAsync();
            return mapper.Map<IList<ViewUsuarioDto>>(consulta);
        }

        public async Task<ViewUsuarioDto> GetByIdAsync(long id)
        {
            Usuario consulta = await serviceUsuario.GetByIdAsync(id);
            return mapper.Map<ViewUsuarioDto>(consulta);
        }

        public async Task<ViewUsuarioDto> PostAsync(PostUsuarioDto post)
        {
            ConverteSenhaEmHash(post);

            Usuario consulta = mapper.Map<Usuario>(post);
            consulta = await serviceUsuario.PostAsync(consulta);
            return mapper.Map<ViewUsuarioDto>(consulta);
        }

        private static void ConverteSenhaEmHash(PostUsuarioDto post)
        {
            var passwordHasher = new PasswordHasher<PostUsuarioDto>();
            post.Senha = passwordHasher.HashPassword(post, post.Senha);
        }

        public async Task<ViewUsuarioDto> PutAsync(PutUsuarioDto put)
        {
            ConverteSenhaEmHash(put);

            Usuario consulta = mapper.Map<Usuario>(put);
            consulta = await serviceUsuario.PutAsync(consulta);
            return mapper.Map<ViewUsuarioDto>(consulta);
        }

        private static void ConverteSenhaEmHash(PutUsuarioDto put)
        {
            var passwordHasher = new PasswordHasher<PutUsuarioDto>();
            put.Senha = passwordHasher.HashPassword(put, put.Senha);
        }

        public async Task<ViewUsuarioDto> DeleteAsync(long id)
        {
            Usuario consulta = await serviceUsuario.DeleteAsync(id);
            return mapper.Map<ViewUsuarioDto>(consulta);
        }

        public async Task<IList<ViewUsuarioDto>> GetNomeAsync(string nome)
        {
            IList<Usuario> consulta = await serviceUsuario.GetNomeAsync(nome);
            return mapper.Map<IList<ViewUsuarioDto>>(consulta);
        }

        public async Task<ViewAposAutenticacaoDto> AutenticacaoAsync(ViewPreAutenticacaoDto viewPreAutenticacao)
        {
            Usuario consulta = await serviceUsuario.GetEmailAsync(viewPreAutenticacao.Email);
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

        public async Task<ViewUsuarioDto> PutStatusAsync(long id)
        {
            Usuario consulta = await serviceUsuario.GetByIdUsuarioAsync(id); 
           
            consulta.ChangeStatusValue((int)Status.Excluido);
            consulta.ChangeAlteradoEmValue(DateTime.Now);

            Usuario obj = await serviceUsuario.PutStatusAsync(consulta);
            return mapper.Map<ViewUsuarioDto>(obj);
        }
    }
}