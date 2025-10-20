using CarBook_1.Application.Features.Mediator.Results.ReviewResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.Mediator.Queries.ReviewQueries
{
    public class GetReviewByCarIdQuery: IRequest<List<GetReviewByCarIdQueryResult>>
    {
        public int Id { get; set; }

        public GetReviewByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
