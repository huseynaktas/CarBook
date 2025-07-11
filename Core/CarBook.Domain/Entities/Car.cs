﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Car
    {
        public int CarId { get; set; }

        //Brand tablosu ile bağlantı
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }

        //CarFeature tablosu ile bağlantı
        public List<CarFeature> CarFeatures { get; set; }

        //CarDescription tablosu ile bağlantı
        public List<CarDescription> CarDescriptions { get; set; }

        //CarPricing tablosu ile bağlantı
        public List<CarPricing> CarPricings { get; set; }

    }
}
