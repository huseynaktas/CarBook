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
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public RemoveServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
