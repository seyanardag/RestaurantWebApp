﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.FooterInfoDto
{
    public class CreateFooterInfoDto
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
		public bool IsActive { get; set; }
	}
}