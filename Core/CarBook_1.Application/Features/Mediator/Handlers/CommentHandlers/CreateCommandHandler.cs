using CarBook.Domain.Entities;
using CarBook_1.Application.Features.Mediator.Commands.CommentCommands;
using CarBook_1.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class CreateCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IRepository<Comment> _repository;

        public CreateCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Comment
            {
                Name = request.Name,
                CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
                BlogId = request.BlogId,
                Description = request.Description,
                Email = request.Email
            });
        }
    }
}
