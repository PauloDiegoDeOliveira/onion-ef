using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Empresa.Projeto.Application.Utilities
{
    public class AuthenticatedUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthenticatedUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Id => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
        public string Email => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;
        public string Role => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Role)?.Value;
        public bool Autenticado => _accessor.HttpContext.User.Identity.IsAuthenticated;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}
