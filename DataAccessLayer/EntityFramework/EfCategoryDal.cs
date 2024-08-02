using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(signalRContext signalRContext) : base(signalRContext)
        {
        }

		public int GetActiveCategoryCount()
		{
			using signalRContext signalRContext = new signalRContext();
			return signalRContext.Categorys.Where(x=>x.Status == true).Count();
		}

		public int GetCategoryCount()
		{
			using signalRContext signalRContext = new signalRContext();
			return signalRContext.Categorys.Count();
		}

        public List<KeyValuePair<string, int>> GetCategoryProductCounts()
        {
			using  (var myContext = new signalRContext())
            {
				var categoryProductCounts = myContext.Categorys.Select(category => new
				{
					categoryName = category.CategoryName,
					categoryCount = myContext.Products.Count(x=>x.CategoryId == category.CategoryId)
				}).ToList();
          
                 var result = categoryProductCounts.Select(x=>new KeyValuePair<string,int>(x.categoryName, x.categoryCount)).ToList();
				return result;

            };

        }

        public int GetPassiveCategoryCount()
		{
			using signalRContext signalRContext = new signalRContext();
			return signalRContext.Categorys.Where(x => x.Status == false).Count();
		}
	}
}
