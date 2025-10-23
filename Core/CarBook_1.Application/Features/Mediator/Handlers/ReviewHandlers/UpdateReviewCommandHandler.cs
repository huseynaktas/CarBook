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
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public UpdateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ReviewId);
            values.CarId = request.CarId;
            values.Comment = request.Comment;
            values.CustomerImg = request.CustomerImg;
            values.CustomerName = request.CustomerName;
            values.RatingValue = request.RatingValue;
            values.ReviewDate = request.ReviewDate;
            await _repository.UpdateAsync(values);
        }
    }
}
