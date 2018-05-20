using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DBContext.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public int DiscountedPrice { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
        public int StoreId { get; set; }
    }
}
