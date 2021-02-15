using PMS.BAL.Interfaces;
using PMS.Common.Models;
using PMS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BAL.Classes
{
    public class CategoryManager : ICategory
    {
        private readonly ICategoryReposiory _categoryRepository;
        public CategoryManager(ICategoryReposiory categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public bool checkCategory(string id)
        {
            return _categoryRepository.checkCategory(id);
        }

        public bool createCategory(Category model)
        {
            return _categoryRepository.createCategory(model);
        }

        public bool deleteCategory(string id)
        {
            return _categoryRepository.deleteCategory(id);
        }

        public List<Category> getAllCategory()
        {
            return _categoryRepository.getAllCategory();
        }

        public Category getCategoryByID(string id)
        {
            return _categoryRepository.getCategoryByID(id);
        }

        public bool updateCategory(Category model)
        {
            return _categoryRepository.updateCategory(model);
        }
    }
}
