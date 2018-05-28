using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IAuthenticationService
    {
        string AuthenticateUser(Login login);
    }
}
