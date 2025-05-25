﻿using CarBook.Domain.Entities;
using CarBook_1.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook_1.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ServiceId);
            values.ServiceId = request.ServiceId;
            values.Description = request.Description;
            values.Title = request.Title;
            values.IconUrl = request.IconUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
