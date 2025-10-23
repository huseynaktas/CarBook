using CarBook.Domain.Entities;
using CarBook_1.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook_1.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public CreateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Review
            {
                CarId = request.CarId,
                Comment = request.Comment,
                CustomerImg = request.CustomerImg,
                CustomerName = request.CustomerName,
                RatingValue = request.RatingValue,
                ReviewDate =DateTime.Parse( DateTime.Now.ToShortDateString())
            });
        }
    }
}
