using EF_DBContext.Models;
using EF_DBContext.Repository_Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DBContext.Repository_Implementation
{
    public class ItemRepository:Repository<Item>, IItemRepository
    {
        public ItemRepository(StoreContext context)
            : base(context)
        {
        }

        private StoreContext StoreContext
        {
            get { return Context as StoreContext; }
        }
    }
}
