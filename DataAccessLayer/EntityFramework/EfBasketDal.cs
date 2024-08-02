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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(signalRContext signalRContext) : base(signalRContext)
        {
        }

        public List<Basket> GetRestaurantTableBasket(int id)
        {
            using var context = new signalRContext();
           return context.Baskets.Where(x => x.RestaurantTableId == id).Include(x=>x.Product).ToList();
        }
    }
}
