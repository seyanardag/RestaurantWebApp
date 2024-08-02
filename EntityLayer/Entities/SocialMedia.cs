using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public string Platform { get; set; }
        public string siteUrl { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
    }
}
