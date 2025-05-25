using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Pricing
    {
        public int PricingId { get; set; }
        public String Name { get; set; }

        //CarPricing tablosu ile bağlantı
        public List<CarPricing> CarPricings { get; set; }
    }
}
