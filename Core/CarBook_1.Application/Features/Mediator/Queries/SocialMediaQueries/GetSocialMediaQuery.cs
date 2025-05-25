using CarBook_1.Application.Features.Mediator.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaQuery: IRequest<List<GetSocialMediaQueryResult>>
    {
    }
}
