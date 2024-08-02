using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.BasketDto
{
    public class ResultBasketDto
    {
        public int BasketId { get; set; }

        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Count { get; set; }



        public int ProductId { get; set; }
      
        public int RestaurantTableId { get; set; }
      
    }
}
