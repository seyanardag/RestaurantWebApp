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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(signalRContext signalRContext) : base(signalRContext)
        {
        }

		public decimal AverageHamburgerPrice()
		{
            using (var context = new signalRContext())
            {
                return context.Products.Where(x => x.CategoryId == (context.Categorys.Where(x => x.CategoryName == "Hamburger").FirstOrDefault().CategoryId)).Average(x => x.Price);
            }
		}

		public decimal GetAverageProductPrice()
		{
            using (var context = new signalRContext())
            {
                return context.Products.Average(x => x.Price);
            }
		}

		public int GetProductCount()
		{
			using (var context = new signalRContext())
            {
                return context.Products.Count();
            }
		}

		public int GetProductCountByCategoryDrink()
		{
			using (var context = new signalRContext())
			{
				//return context.Products.Where(x => x.Category.CategoryName == "Hamburger").Count();
				return context.Products.Where(x => x.CategoryId == (context.Categorys.Where(x => x.CategoryName == "İçecek").FirstOrDefault().CategoryId)).Count();
			}
		}

		public int GetProductCountByHamburger()
		{
			using (var context = new signalRContext())
            {
                //return context.Products.Where(x => x.Category.CategoryName == "Hamburger").Count();
                return context.Products.Where(x => x.CategoryId == (context.Categorys.Where(x => x.CategoryName == "Hamburger").FirstOrDefault().CategoryId)).Count();
            }
		}

		public string GetProductNameByMaxPrice()
		{
			using (var context = new signalRContext())
            {
                return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).FirstOrDefault().ProductName;
            }
		}

		public string GetProductNameByMinPrice()
		{
			using (var context = new signalRContext())
			{
				return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).FirstOrDefault().ProductName;
			}
		}

		public List<Product> GetProductsWithCategories()
        {



            using (var context = new signalRContext())
            {
                var values = context.Products.Include(x => x.Category).Select(x => new Product()
                {
                    ProductId = x.ProductId,
                    Description = x.Description,
                    ImgUrl = x.ImgUrl,
                    Price = x.Price,
                    ProductName = x.ProductName,
                    ProductStatus = x.ProductStatus,
                    CategoryId = x.CategoryId,

                }).ToList();
                return values;
            }
        }
    }
}
