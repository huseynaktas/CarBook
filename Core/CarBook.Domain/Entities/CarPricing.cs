using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CarPricing
    {
        public int CarPricingId { get; set; }

        //Car tablosu ile bağlantı
        public int CarId { get; set; }
        public Car Car { get; set; }

        //Pricing tablosu ile bağlantı
        public int PricingId { get; set; }
        public Pricing Pricing { get; set; }
        public decimal Amount { get; set; }
    }
}
