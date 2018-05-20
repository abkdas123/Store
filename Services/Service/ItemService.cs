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
    public class ItemService : IItemService
    {
        public UnitOfWork uow = null;

        public ItemService()
        {
            uow = new UnitOfWork(new StoreContext());
        }

        public IEnumerable<Item> GetAllItems()
        {   
            var items = uow.ItemRepository.GetAll();
            return items;
        }

        public IEnumerable<Item> AddItem(Item item)
        {
            IEnumerable<Item> allItems = null;            
            uow.ItemRepository.Add(item);

            if (uow.Complete())
                allItems = GetAllItems();

            return allItems;
        }

        public IEnumerable<Item> UpdateItem(Item item)
        {
            IEnumerable<Item> allItems = null;
            Item existingItem = uow.ItemRepository.Get(item.Id);

            if (existingItem != null)
            {
                existingItem.CategoryId = item.CategoryId;
                existingItem.DiscountedPrice = item.DiscountedPrice;
                existingItem.ImagePath = item.ImagePath;
                existingItem.Price = item.Price;
                existingItem.IsActive = item.IsActive;
                existingItem.Quantity = item.Quantity;
                existingItem.Name = item.Name;
                existingItem.StoreId = item.StoreId;
                
                // uow.update
                if (uow.Complete())
                    allItems = GetAllItems();
            }

            return allItems;
        }

        public IEnumerable<Item> DeleteItem(int itemId)
        {
            IEnumerable<Item> allItems = null;

             Item existingItem = uow.ItemRepository.Get(itemId);

             if (existingItem != null)
             {
                 uow.ItemRepository.Remove(existingItem);
                 if (uow.Complete())
                     allItems = GetAllItems();
             }

            return allItems;
        }

        private Item GetItem(int itemId)
        {
            return uow.ItemRepository.Get(itemId);
        }

        private int GetUserId(string token)
        {
            return uow.UserRepository.GetUserId(token);
        }
    }
}
