using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> GetProductsWithCategories();
        int TGetProductCount();
		int TGetProductCountByHamburger();
		int TGetProductCountByCategoryDrink();
		decimal TGetAverageProductPrice();
		string TGetProductNameByMaxPrice();
		string TGetProductNameByMinPrice();
		decimal TAverageHamburgerPrice();


	}
}
