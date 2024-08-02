using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.ContactDto
{
    public class CreateContactDto
    {
 
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
		public bool isSelected { get; set; }

	}
}
