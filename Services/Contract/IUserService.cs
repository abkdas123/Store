using EF_DBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IUserService
    {
        IEnumerable<MstUser> GetAllUsers();

        IEnumerable<MstUser> AddUser(MstUser user);

        IEnumerable<MstUser> UpdateUser(MstUser user);

        IEnumerable<MstUser> DeleteUser(int userId);
    }
}
