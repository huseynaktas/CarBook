﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Dto.BannerDtos
{
    public class ResultBannerDto
    {
        public int bannerId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string videoDescription { get; set; }
        public string videoUrl { get; set; }
    }
}
