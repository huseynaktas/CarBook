using CarBook.Domain.Entities;
using CarBook_1.Application.Features.CQRS.Queries.ContactQueries;
using CarBook_1.Application.Features.CQRS.Results.ContactResults;
using CarBook_1.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                Email = values.Email,
                Message = values.Message,
                SendDate = values.SendDate,
                Subject = values.Subject
            };
        }
    }
}
