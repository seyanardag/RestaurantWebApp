using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class DiscountedProduct
    {
        [Key]
        public int DiscountedProductId { get; set; }
        public string Title { get; set; }
        
        public int DiscountRate { get; set; }
        public string ImgUrl { get; set; }
        public bool isActive { get; set; }


    }
}
