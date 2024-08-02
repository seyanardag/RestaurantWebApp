using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        int GetProductCount();
        int GetProductCountByHamburger();
        int GetProductCountByCategoryDrink();
        decimal GetAverageProductPrice();
        string GetProductNameByMinPrice();
        string GetProductNameByMaxPrice();
        decimal AverageHamburgerPrice();
    }
}
