using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EF_DBContext.Models
{
    public class MstCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int StoreTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
