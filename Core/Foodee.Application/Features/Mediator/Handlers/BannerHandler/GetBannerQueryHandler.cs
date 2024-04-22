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
    public class GetBannerQueryHandler : IRequestHandler<GetBannerQuery, List<GetBannerQueryResult>>
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBannerQueryResult>> Handle(GetBannerQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBannerQueryResult
            {
                BannerId = x.BannerId,
                CoverImageUrl = x.CoverImageUrl,
                Description = x.Description,
                Title = x.Title
            }).ToList();
        }
    }
}
