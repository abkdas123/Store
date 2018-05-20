using EF_DBContext;
using EF_DBContext.Models;
using EF_DBContext.Unit;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    //Author: Shriyansh
    public class StoreService : IStoreService
    {
        public UnitOfWork uow = null;

        public StoreService()
        {
            uow = new UnitOfWork(new StoreContext());
        }

        public IEnumerable<MstStore> GetAllStores()
        {   
            var stores = uow.StoreRepository.GetAll();
            return stores;
        }

        public IEnumerable<MstStore> AddStore(MstStore store)
        {
            IEnumerable<MstStore> allStores = null;
            store.CreatedDate = DateTime.Now;
            store.ModifiedDate = DateTime.Now;
            store.CreatedBy = this.GetUserId("");
            store.ModifiedBy = this.GetUserId("");
            uow.StoreRepository.Add(store);

            if (uow.Complete())
                allStores = GetAllStores();

            return allStores;
        }

        public IEnumerable<MstStore> UpdateStore(MstStore store)
        {
            IEnumerable<MstStore> allStores = null;
            MstStore existingStore = uow.StoreRepository.Get(store.Id);

            if (existingStore != null)
            {
                existingStore.Address = store.Address;
                existingStore.AltPhone = store.Address;
                existingStore.CityId = store.CityId;
                existingStore.ModifiedBy = this.GetUserId("");
                existingStore.IsActive = store.IsActive;
                existingStore.ModifiedDate = DateTime.Now;
                existingStore.Name = store.Name;
                existingStore.Phone = store.Phone;
                existingStore.Pincode = store.Pincode;
                
                // uow.update
                if (uow.Complete())
                    allStores = GetAllStores();
            }

            return allStores;
        }

        public IEnumerable<MstStore> DeleteStore(int storeId)
        {
            IEnumerable<MstStore> allStores = null;

             MstStore existingStore = uow.StoreRepository.Get(storeId);

             if (existingStore != null)
             {
                 uow.StoreRepository.Remove(existingStore);
                 if (uow.Complete())
                     allStores = GetAllStores();
             }

            return allStores;
        }

        private MstStore GetStore(int storeId)
        {
            return uow.StoreRepository.Get(storeId);
        }

        private int GetUserId(string token)
        {
            return uow.UserRepository.GetUserId(token);
        }
    }
}
