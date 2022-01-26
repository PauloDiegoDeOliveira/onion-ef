using AutoMapper;
using Empresa.Projeto.Application.Dtos.Usuario;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application
{
    public class ApplicationServiceUsuario : IApplicationServiceUsuario
    {
        private readonly IServiceUsuario serviceUsuario;
        private readonly IMapper mapper;

        public ApplicationServiceUsuario(IServiceUsuario serviceUsuario,
                                         IMapper mapper)
        {
            this.serviceUsuario = serviceUsuario;
            this.mapper = mapper;
        }

        public async Task<IList<ViewUsuarioDto>> GetAllAsync()
        {
            var consulta = await serviceUsuario.GetAllAsync();
            return mapper.Map<IList<ViewUsuarioDto>>(consulta);
        }

        public async Task<ViewUsuarioDto> GetByIdAsync(long id)
        {
            var consulta = await serviceUsuario.GetByIdAsync(id);
            return mapper.Map<ViewUsuarioDto>(consulta);
        }

        public async Task<ViewUsuarioDto> PostAsync(PostUsuarioDto post)
        {
            ConverteSenhaEmHash(post);

            var consulta = mapper.Map<Usuario>(post);
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

            var consulta = mapper.Map<Usuario>(put);
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
            var consulta = await serviceUsuario.DeleteAsync(id);
            return mapper.Map<ViewUsuarioDto>(consulta);
        }

        public async Task<IList<ViewUsuarioDto>> GetNomeAsync(string nome)
        {
            IList<Usuario> consulta = await serviceUsuario.GetNomeAsync(nome);           
            return mapper.Map<IList<ViewUsuarioDto>>(consulta);
        }
    }
}