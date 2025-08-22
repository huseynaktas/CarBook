using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.Mediator.Commands.ReservationCommands
{
    public class CreateReservationCommand: IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public int CarId { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string Description { get; set; }
    }
}
