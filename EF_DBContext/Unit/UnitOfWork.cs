using EF_DBContext.Repository_Contracts;
using EF_DBContext.Repository_Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DBContext.Unit
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        public IStoreRepository StoreRepository { get; private set; }

        public IStoreTypeRepository StoreTypeRepository { get; private set; }
        
        public IUserRepository UserRepository { get; private set; }

        public IItemRepository ItemRepository { get; private set; }

        public ICategoryRepository CategoryRepository { get; private set; }
        
        public UnitOfWork(StoreContext context)
        {
            _context = context;
            StoreRepository = new StoreRepository(_context);
            StoreTypeRepository = new StoreTypeRepository(_context);
            UserRepository = new UserRepository(_context);
            ItemRepository = new ItemRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
        }

        public bool Complete()
        {
            return _context.SaveChanges() > 0 ? true: false;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
