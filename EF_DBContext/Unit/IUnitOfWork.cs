using EF_DBContext.Repository_Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DBContext.Unit
{
    public interface IUnitOfWork : IDisposable
    {
        IStoreRepository StoreRepository { get; }
        bool Complete();
    }
}
