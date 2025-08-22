using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Dto.ReservationDtos
{
    public class CreateReservationDto
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string emailAddress { get; set; }
        public string phone { get; set; }
        public int pickUpLocationId { get; set; }
        public int dropOffLocationId { get; set; }
        public int carId { get; set; }
        public int age { get; set; }
        public int driverLicenseYear { get; set; }
        public string description { get; set; }
    }
}
