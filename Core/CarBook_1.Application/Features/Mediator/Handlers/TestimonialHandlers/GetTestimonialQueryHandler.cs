﻿using CarBook.Domain.Entities;
using CarBook_1.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook_1.Application.Features.Mediator.Results.TestimonialResults;
using CarBook_1.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTestimonialQueryResult
            {
                TestimonialId = x.TestimonialId,
                Comment = x.Comment,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Title = x.Title
            }).ToList();
        }
    }
}
