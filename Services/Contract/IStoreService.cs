using EF_DBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IStoreService
    {
        IEnumerable<MstStore> GetAllStores();

        IEnumerable<MstStore> AddStore(MstStore store);

        IEnumerable<MstStore> UpdateStore(MstStore store);

        IEnumerable<MstStore> DeleteStore(int storeId);
    }
}
