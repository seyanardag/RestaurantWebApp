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
	public class ProductManager : IProductService
	{
		private readonly IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public decimal TAverageHamburgerPrice()
		{
			return _productDal.AverageHamburgerPrice();
		}

		public List<Product> GetProductsWithCategories()
		{
			return _productDal.GetProductsWithCategories();
		}

		public void TAdd(Product entity)
		{
			_productDal.Add(entity);
		}

		public void TDelete(Product entity)
		{
			_productDal.Delete(entity);
		}

		public List<Product> TGetAll()
		{
			return _productDal.GetAll();
		}

		public decimal TGetAverageProductPrice()
		{
			return _productDal.GetAverageProductPrice();
		}

		public Product TGetById(int id)
		{
			return _productDal.GetById(id);
		}

		public int TGetProductCount()
		{
			return _productDal.GetProductCount();
		}

		public int TGetProductCountByCategoryDrink()
		{
			return _productDal.GetProductCountByCategoryDrink();
		}

		public int TGetProductCountByHamburger()
		{
			return _productDal.GetProductCountByHamburger();
		}

		public string TGetProductNameByMaxPrice()
		{
			return _productDal.GetProductNameByMaxPrice();
		}

		public string TGetProductNameByMinPrice()
		{
			return _productDal.GetProductNameByMinPrice();
		}

		public void TUpdate(Product entity)
		{
			_productDal.Update(entity);
		}


	}
}
