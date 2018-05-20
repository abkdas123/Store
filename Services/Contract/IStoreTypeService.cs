using EF_DBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    interface IStoreTypeService
    {
        IEnumerable<MstStoreType> GetAllStores();

        IEnumerable<MstStoreType> AddStore(MstStoreType storeType);

        IEnumerable<MstStoreType> UpdateStore(MstStoreType storeType);

        IEnumerable<MstStoreType> DeleteStore(int storeTypeId);
    }
}
