﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.TestimonialDto
{
    public class CreateTestimonialDto
    {
       
        public string WriterName { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImgUrl { get; set; }
        public bool Status { get; set; }
    }
}
