﻿using CarBook.Domain.Entities;
using CarBook_1.Application.Features.CQRS.Commands.BrandCommands;
using CarBook_1.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBrandCommand command)
        {
            await _repository.CreateAsync(new Brand
            {
                Name = command.Name
            });
        }
    }
}
