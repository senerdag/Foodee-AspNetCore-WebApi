using Foodee.Application.Features.Mediator.Queries.BannerQueries;
using Foodee.Application.Features.Mediator.Results.BannerResults;
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
    public class GetBannerByIdQueryHandler : IRequestHandler<GetBannerByIdQuery, GetBannerByIdQueryResult>
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetBannerByIdQueryResult
            {
                BannerId = values.BannerId,
                CoverImageUrl = values.CoverImageUrl,
                Description = values.Description,
                Title = values.Title
            };
        }
    }
}
