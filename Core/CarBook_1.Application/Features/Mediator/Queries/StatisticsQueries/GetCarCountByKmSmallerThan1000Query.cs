﻿using CarBook_1.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetCarCountByKmSmallerThan1000Query: IRequest<GetCarCountByKmSmallerThan1000QueryResult>
    {
    }
}
