﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.CQRS.Results.CarResults
{
    public class GetLast5CarWithBrandQueryResult
    {
        public int CarId { get; set; }
        //Farklı tablo ile bağlantı
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
    }
}
