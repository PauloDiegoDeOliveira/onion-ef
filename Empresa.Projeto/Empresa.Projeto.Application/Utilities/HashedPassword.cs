using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Projeto.Application.Utilities
{
    public class HashedPassword
    {
        public string Password { get; private set; }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}
