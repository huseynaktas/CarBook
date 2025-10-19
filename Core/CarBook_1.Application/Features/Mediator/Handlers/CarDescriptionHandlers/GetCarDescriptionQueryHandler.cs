using CarBook.Domain.Entities;
using CarBook_1.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook_1.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook_1.Application.Interfaces;
using CarBook_1.Application.Interfaces.CarDescriptionInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionQueryHandler : IRequestHandler<GetCarDescriptionQuery, GetCarDescriptionQueryResult>
    {
        private readonly ICarDescriptionRepository _repository;

        public GetCarDescriptionQueryHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionQueryResult> Handle(GetCarDescriptionQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarDescription(request.Id);
            return new GetCarDescriptionQueryResult
            {
                CarDescriptionId = values.CarDescriptionId,
                CarId = values.CarId,
                Details = values.Details
            };
        }
    }
}
