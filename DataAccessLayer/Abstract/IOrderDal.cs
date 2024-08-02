using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IOrderDal : IGenericDal<Order>
	{
		int GetTotalOrderCount();
		int ActiveOrderCount(); //TODO:Burada Description "Müşteri Masada" olanlar aktif sipariş olarak alındı, yeni field eklenip true olanlar alınabilir.
		decimal LastOrderPrice();

		decimal EndorsementToday();
	}
}
