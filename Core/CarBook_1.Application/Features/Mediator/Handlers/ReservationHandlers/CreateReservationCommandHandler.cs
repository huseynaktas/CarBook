using CarBook.Domain.Entities;
using CarBook_1.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook_1.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation
            {
                Name = request.Name,
                Surname = request.Surname,
                EmailAddress = request.EmailAddress,
                Phone = request.Phone,
                PickUpLocationId = request.PickUpLocationId,
                DropOffLocationId = request.DropOffLocationId,
                CarId = request.CarId,
                Age = request.Age,
                DriverLicenseYear = request.DriverLicenseYear,
                Description = request.Description,
                Status = "Rezervasyon Alındı"
            });
        }
    }
}
