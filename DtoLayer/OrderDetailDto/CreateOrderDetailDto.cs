using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.OrderDetailDto
{
	public class CreateOrderDetailDto
	{
		
		public int ProductId { get; set; }
		
		public int ProductCount { get; set; }
		public decimal ProductPrice { get; set; }
		public decimal TotalPrice { get; set; }



		public int OrderId { get; set; }
	}
}
