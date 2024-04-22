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
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Banner
            {
                CoverImageUrl = request.CoverImageUrl,
                Description = request.Description,
                Title = request.Title

            });
        }
    }
}
