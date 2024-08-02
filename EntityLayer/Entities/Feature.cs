using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Feature  //Burada Titele1, desc1  -2,3 olarak kodlamış, ben tek kodladım, bu daha esnek
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
