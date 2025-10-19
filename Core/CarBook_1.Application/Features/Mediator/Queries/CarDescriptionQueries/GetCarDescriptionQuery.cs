using CarBook_1.Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionQuery: IRequest<GetCarDescriptionQueryResult>
    {
        public int Id { get; set; }

        public GetCarDescriptionQuery(int id)
        {
            Id = id;
        }
    }
}
