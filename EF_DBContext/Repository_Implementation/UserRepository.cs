using EF_DBContext.Models;
using EF_DBContext.Repository_Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DBContext.Repository_Implementation
{
    public class UserRepository : Repository<MstUser>, IUserRepository
    {
        public UserRepository(StoreContext context)
            : base(context)
        {
        }

        public int GetUserId(string token)
        {
            return StoreContext.MstUser.Where(x=>x.Id == 1).FirstOrDefault().Id;
        }

        private StoreContext StoreContext
        {
            get { return Context as StoreContext; }
        }
    }
}
