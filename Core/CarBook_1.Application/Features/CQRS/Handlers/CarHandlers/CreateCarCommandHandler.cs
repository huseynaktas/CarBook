using CarBook.Domain.Entities;
using CarBook_1.Application.Features.CQRS.Commands.CarCommands;
using CarBook_1.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {
                BigImageUrl = command.BigImageUrl,
                Luggage = command.Seat,
                Km = command.Km,
                Seat = command.Seat,
                Model = command.Model,
                CoverImageUrl = command.CoverImageUrl,
                BrandId = command.BrandId,
                Fuel = command.Fuel,
                Transmission = command.Transmission
            });
        }
    }
}
