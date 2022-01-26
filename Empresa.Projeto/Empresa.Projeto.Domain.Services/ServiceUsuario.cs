﻿using Empresa.Projeto.Domain.Core.Interfaces.Repositorys;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
using Empresa.Projeto.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Projeto.Domain.Services
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        private readonly IRepositoryUsuario repositoryUsuario;

        public ServiceUsuario(IRepositoryUsuario repositoryUsuario) : base(repositoryUsuario)
        {
            this.repositoryUsuario = repositoryUsuario;
        }

        public async Task<IList<Usuario>> GetNomeAsync(string nome)
        {
            return await repositoryUsuario.GetNomeAsync(nome);
        }

        public async Task<Usuario> GetEmailAsync(string email)
        {
            return await repositoryUsuario.GetEmailAsync(email);
        }

        public async Task<Usuario> PutStatusAsync(Usuario usuario)
        {
            return await repositoryUsuario.PutStatusAsync(usuario);
        }

        public async Task<Usuario> GetByIdUsuarioAsync(long id) 
        { 
            return await repositoryUsuario.GetByIdUsuarioAsync(id);
        }
    }
}