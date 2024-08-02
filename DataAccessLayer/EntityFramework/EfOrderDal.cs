using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EfOrderDal(signalRContext signalRContext) : base(signalRContext)
		{
		}

		public int GetTotalOrderCount()
		{
			using (var context = new signalRContext())
			{
				return context.Orders.Count();
			}
		}
		public int ActiveOrderCount ()
		{
			using (var context = new signalRContext())
			{
				return context.Orders.Where(x=>x.Description=="Müşteri Masada").Count();
			}
		}

		public decimal LastOrderPrice()
		{
			using (var context = new signalRContext())
			{
				return context.Orders.OrderByDescending(x=>x.OrderDate).Take(1).Select(x=>x.TotalPrice).FirstOrDefault();
			}
		}

		public decimal EndorsementToday()
		{
			using (var context = new signalRContext())
			{
				DateTime today =DateTime.Now;
				var value = context.Orders
					.Where(
					x => x.Description == "Hesap Kapatıldı" &&
					x.OrderDate.Year == today.Year &&
					x.OrderDate.Month == today.Month &&
					x.OrderDate.Day == today.Day
					)
					.Sum(z=>z.TotalPrice);
				return value;
			}
		}
	}
}
