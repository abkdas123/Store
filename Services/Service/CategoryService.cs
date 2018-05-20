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
    public class CategoryService : ICategoryService
    {
        public UnitOfWork uow = null;

        public CategoryService()
        {
            uow = new UnitOfWork(new StoreContext());
        }

        public IEnumerable<MstCategory> GetAllCategorys()
        {   
            var categorys = uow.CategoryRepository.GetAll();
            return categorys;
        }

        public IEnumerable<MstCategory> AddCategory(MstCategory category)
        {
            IEnumerable<MstCategory> allCategorys = null;
            uow.CategoryRepository.Add(category);

            if (uow.Complete())
                allCategorys = GetAllCategorys();

            return allCategorys;
        }

        public IEnumerable<MstCategory> UpdateCategory(MstCategory category)
        {
            IEnumerable<MstCategory> allCategorys = null;
            MstCategory existingCategory = uow.CategoryRepository.Get(category.Id);

            if (existingCategory != null)
            {
                existingCategory.IsActive = category.IsActive;
                existingCategory.Name = category.Name;
                existingCategory.StoreTypeId = category.StoreTypeId;
                
                // uow.update
                if (uow.Complete())
                    allCategorys = GetAllCategorys();
            }

            return allCategorys;
        }

        public IEnumerable<MstCategory> DeleteCategory(int categoryId)
        {
            IEnumerable<MstCategory> allCategorys = null;

             MstCategory existingCategory = uow.CategoryRepository.Get(categoryId);

             if (existingCategory != null)
             {
                 uow.CategoryRepository.Remove(existingCategory);
                 if (uow.Complete())
                     allCategorys = GetAllCategorys();
             }

            return allCategorys;
        }

        private MstCategory GetCategory(int categoryId)
        {
            return uow.CategoryRepository.Get(categoryId);
        }

        private int GetUserId(string token)
        {
            return uow.UserRepository.GetUserId(token);
        }
    }
}
