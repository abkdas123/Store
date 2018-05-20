using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DBContext.Models
{
    public class MstCity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
