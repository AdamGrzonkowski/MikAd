using System.Collections.Generic;
using System.Linq;
using Shop.Model.Models;

namespace Shop.Model.Repositories
{
    class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext _shopContext;

        public CategoryRepository()
        {
            _shopContext = new ShopContext();
        }

        public void Dispose()
        {
            _shopContext.Dispose();
        }

        public IQueryable<Category> GetAll()
        {
            return _shopContext.Categories;
        }

        public Category GetById(int id)
        {
            return _shopContext.Categories.SingleOrDefault(x => x.Id == id);
        }

        public int Add(Category entity)
        {
            _shopContext.Categories.Add(entity);
            _shopContext.SaveChanges();

            return entity.Id;
        }

        public void Update(int id, Category entity)
        {
            Category dbCategory = GetById(id);
            dbCategory.Name = entity.Name;
            dbCategory.BaseCategory = entity.BaseCategory;
            dbCategory.BaseCategoryId = entity.BaseCategoryId;
            _shopContext.SaveChanges();
        }

        public void Delete(Category entity)
        {
            _shopContext.Categories.Remove(entity);
        }

        public void Delete(int id)
        {
            Category dbCategory = GetById(id);
            _shopContext.Categories.Remove(dbCategory);
        }

        public Category GetByName(string categoryName)
        {
            return _shopContext.Categories.SingleOrDefault(x => x.Name == categoryName);
        }

        public IEnumerable<Category> GetAllSubCategories(string categoryName)
        {
            Category dbCategory = _shopContext.Categories.SingleOrDefault(x => x.Name == categoryName);
            if (dbCategory != null) return dbCategory.SubCategories;
            return null;
        }

        public IEnumerable<Category> GetAllSubCategories(Category category)
        {
            return category.SubCategories;
        }

        public IEnumerable<Category> GetAllSubCategories(int categoryId)
        {
            Category dbCategory = _shopContext.Categories.SingleOrDefault(x => x.Id == categoryId);
            if (dbCategory != null) return dbCategory.SubCategories;
            return null;
        }

        public Category GetRootCategory(string categoryName)
        {
            Category category = _shopContext.Categories.SingleOrDefault(x => x.Name == categoryName);
            if (category == null)
            {
                return null;
            }
            Category rootCategory = category;
            while (rootCategory.BaseCategoryId != null)
            {
                rootCategory = rootCategory.BaseCategory;
            }
            return rootCategory;
        }

        public Category GetRootCategory(Category category)
        {
            if (category == null)
            {
                return null;
            }
            Category rootCategory = category;
            while (rootCategory.BaseCategoryId != null)
            {
                rootCategory = rootCategory.BaseCategory;
            }
            return rootCategory;
        }

        public Category GetRootCategory(int categoryId)
        {
            Category category = _shopContext.Categories.SingleOrDefault(x => x.Id == categoryId);
            if (category == null)
            {
                return null;
            }
            Category rootCategory = category;
            while (rootCategory.BaseCategoryId != null)
            {
                rootCategory = rootCategory.BaseCategory;
            }
            return rootCategory;
        }
    }
}