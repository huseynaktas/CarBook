using CarBook.Domain.Entities;
using CarBook_1.Application.Features.CQRS.Queries.BrandQueries;
using CarBook_1.Application.Features.CQRS.Results.BrandResults;
using CarBook_1.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandByIdQureyResult> Handle(GetBrandByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetBrandByIdQureyResult
            {
                BrandId = values.BrandId,
                Name = values.Name
            };
        }
    }
}
