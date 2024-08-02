using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.RestaurantTableDto
{
	public class GetRestaurantTableDto
	{
		public int RestaurantTableId { get; set; }
		public string TableName { get; set; }
		public bool Status { get; set; }
	}
}
