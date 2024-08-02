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
    public class DiscountedProductManager : IDiscountedProductService
    {
        private readonly IDiscountedProductDal _discountedProductDal;
        public DiscountedProductManager(IDiscountedProductDal discountedProductDal)
        {
            _discountedProductDal = discountedProductDal;   
        }

        public void TAdd(DiscountedProduct entity)
        {
            _discountedProductDal.Add(entity);
        }

        public void TDelete(DiscountedProduct entity)
        {
            _discountedProductDal.Delete(entity);
        }

        public List<DiscountedProduct> TGetAll()
        {
            return _discountedProductDal.GetAll();  
        }

        public DiscountedProduct TGetById(int id)
        {
            return _discountedProductDal.GetById(id);   
        }

        public void TUpdate(DiscountedProduct entity)
        {
            _discountedProductDal.Update(entity);
        }
    }
}
