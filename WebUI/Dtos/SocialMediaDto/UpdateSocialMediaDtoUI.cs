using System;
using System.Collections.Generic;
using System.Linq;
namespace WebUI.Dtos.SocialMediaDto

{
    public class UpdateSocialMediaDtoUI
    {
        public int SocialMediaId { get; set; }
        public string Platform { get; set; }
        public string siteUrl { get; set; }
        public string Icon { get; set; }
		public bool IsActive { get; set; }
	}
}
