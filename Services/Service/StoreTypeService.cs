using EF_DBContext;
using EF_DBContext.Models;
using EF_DBContext.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class StoreTypeService
    {
        public UnitOfWork uow = null;

        public StoreTypeService()
        {
            uow = new UnitOfWork(new StoreContext());
        }

        public IEnumerable<MstStoreType> GetAllStoreTypes()
        {   
            var storeTypes = uow.StoreTypeRepository.GetAll();
            return storeTypes;
        }

        public IEnumerable<MstStoreType> AddStoreType(MstStoreType storeType)
        {
            IEnumerable<MstStoreType> allStoreTypes = null;
           
            uow.StoreTypeRepository.Add(storeType);

            if (uow.Complete())
                allStoreTypes = GetAllStoreTypes();

            return allStoreTypes;
        }

        public IEnumerable<MstStoreType> UpdateStoreType(MstStoreType storeType)
        {
            IEnumerable<MstStoreType> allStoreTypes = null;
            MstStoreType existingStoreType = uow.StoreTypeRepository.Get(storeType.Id);

            if (existingStoreType != null)
            {
                existingStoreType.Name = storeType.Name;
                existingStoreType.IsActive = storeType.IsActive;
                
                // uow.update
                if (uow.Complete())
                    allStoreTypes = GetAllStoreTypes();
            }

            return allStoreTypes;
        }

        public IEnumerable<MstStoreType> DeleteStoreType(int storeTypeId)
        {
            IEnumerable<MstStoreType> allStoreTypes = null;

             MstStoreType existingStoreType = uow.StoreTypeRepository.Get(storeTypeId);

             if (existingStoreType != null)
             {
                 uow.StoreTypeRepository.Remove(existingStoreType);
                 if (uow.Complete())
                     allStoreTypes = GetAllStoreTypes();
             }

            return allStoreTypes;
        }

        private MstStoreType GetStoreType(int storeTypeId)
        {
            return uow.StoreTypeRepository.Get(storeTypeId);
        }

        private int GetUserId(string token)
        {
            return uow.UserRepository.GetUserId(token);
        }
    }
}
