using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.FeatureDto
{
    public class UpdateFeatureDto
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
