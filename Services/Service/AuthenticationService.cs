using Models.ViewModels;
using Services.Contract;
using Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class AuthenticationService : IAuthenticationService
    {

        public string AuthenticateUser(Login login)
        {
            return JWT_Configuration.GenerateToken(login.EmailId, 20);
        }
    }
}
