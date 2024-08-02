using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DiscountedProductDto
{
    public class CreateDiscountedProductDto
    {
        
        public string Title { get; set; }
        public int DiscountRate { get; set; }
        public string ImgUrl { get; set; }
		public bool isActive { get; set; }
	}
}
