﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }

        //CarFeature tablosu ile bağlantı
        public List<CarFeature> CarFeatures { get; set; }
    }
}
