using EF_DBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface ICategoryService
    {
        IEnumerable<MstCategory> GetAllCategorys();

        IEnumerable<MstCategory> AddCategory(MstCategory category);

        IEnumerable<MstCategory> UpdateCategory(MstCategory category);

        IEnumerable<MstCategory> DeleteCategory(int categoryId);
    }
}
