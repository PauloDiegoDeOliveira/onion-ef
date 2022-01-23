using AutoMapper;
using Empresa.Projeto.Application.Dtos.Usuario;
using Empresa.Projeto.Application.Interfaces;
using Empresa.Projeto.Domain.Core.Interfaces.Services;
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

        public async Task<IEnumerable<ViewUsuarioDto>> GetAllAsync()
        {
            var consulta = await serviceUsuario.GetAllAsync();
            return mapper.Map<IEnumerable<ViewUsuarioDto>>(consulta);
        }
    }
}