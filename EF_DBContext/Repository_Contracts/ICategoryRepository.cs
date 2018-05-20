using EF_DBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DBContext.Repository_Contracts
{
    public interface ICategoryRepository : IRepository<MstCategory>
    {
    }
}
