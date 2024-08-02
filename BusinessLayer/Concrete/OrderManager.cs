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
	public class OrderManager : IOrderService
	{
		private readonly IOrderDal _orderDal;

		public OrderManager(IOrderDal orderDal)
		{
			_orderDal = orderDal;
		}

		public int TGetTotalOrderCount()
		{
			return _orderDal.GetTotalOrderCount();
		}

		public void TAdd(Order entity)
		{
			_orderDal.Add(entity);
			
		}

		public void TDelete(Order entity)
		{
			_orderDal.Delete(entity);
		}

		public List<Order> TGetAll()
		{
			return _orderDal.GetAll();
		}

		public Order TGetById(int id)
		{
			return _orderDal.GetById(id);
		}

		public void TUpdate(Order entity)
		{
			_orderDal.Update(entity);	
		}

		public int TActiveOrderCount()
		{
			return _orderDal.ActiveOrderCount();
		}

		public decimal TLastOrderPrice()
		{
			return _orderDal.LastOrderPrice();
		}

		public decimal TEndorsementToday()
		{
			return _orderDal.EndorsementToday();
		}
	}
}
