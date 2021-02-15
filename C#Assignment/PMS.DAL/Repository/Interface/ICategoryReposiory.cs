using PMS.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.Repository.Interface
{
   public interface ICategoryReposiory
    {

        bool createCategory(Category model);
        bool updateCategory(Category model);
        bool deleteCategory(String id);
        List<Category> getAllCategory();
        Category getCategoryByID(String id);
        bool checkCategory(String id);
    }
}
