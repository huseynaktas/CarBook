using CarBook_1.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudQuery: IRequest<List<GetTagCloudQueryResult>>
    {
    }
}
