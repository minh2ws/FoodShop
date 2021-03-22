using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Model
{
    interface ICategoryModel
    {
        List<TblCategoryDTO> getAll();
        bool updateCategory(TblCategoryDTO categoryDTO);
        bool addCategory(TblCategoryDTO categoryDTO);
    }
}
