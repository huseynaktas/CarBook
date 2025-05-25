using CarBook_1.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingWithCarQuery: IRequest<List<GetCarPricingWithCarQueryResult>>
    {
    }
}
