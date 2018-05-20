using EF_DBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IItemService
    {
        IEnumerable<Item> GetAllItems();

        IEnumerable<Item> AddItem(Item item);

        IEnumerable<Item> UpdateItem(Item item);

        IEnumerable<Item> DeleteItem(int itemId);
    }
}
