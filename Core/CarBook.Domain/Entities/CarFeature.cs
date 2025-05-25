using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CarFeature
    {
        public int CarFeatureId { get; set; }

        //Car tablosu ile bağlantı
        public int CarId { get; set; }
        public Car Car { get; set; }

        //Feature tablosu ile bağantı
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
        public bool Available { get; set; }
    }
}
