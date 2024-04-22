using Foodee.Application.Features.Mediator.Commands.BannerCommands;
using Foodee.Application.Interfaces;
using Foodee.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Handlers.BannerHandler
{
    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BannerId);
            values.Description = request.Description;
            values.CoverImageUrl = request.CoverImageUrl;
            values.Title = request.Title;
            await _repository.UpdateAsync(values);
        }
    }
}
