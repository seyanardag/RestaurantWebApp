using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

		public int TGetCategoryCount()
		{
			return _categoryDal.GetCategoryCount();
		}

		public void TAdd(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public List<Category> TGetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }

		public int TGetActiveCategoryCount()
		{
			return _categoryDal.GetActiveCategoryCount();
		}

		public int TGetPassiveCategoryCount()
		{
			return _categoryDal.GetPassiveCategoryCount();
		}

        public List<KeyValuePair<string, int>> TGetCategoryProductCounts()
        {
            return _categoryDal.GetCategoryProductCounts();
        }
    }
}
