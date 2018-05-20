using EF_DBContext.Models;
using EF_DBContext.Repository_Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DBContext.Repository_Implementation
{
    public class StoreRepository : Repository<MstStore>, IStoreRepository
    {
        public StoreRepository(StoreContext context)
            : base(context)
        {
        }

        public IEnumerable<MstStore> GetStoreWithPaging(int pageIndex, int pageSize = 10)
        {
            return StoreContext.MstStore
                    .OrderBy(c => c.Name)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
        }

        private StoreContext StoreContext
        {
            get { return Context as StoreContext; }
        }
    }
}
