using Foodee.Application.Features.Mediator.Queries.AboutQueries;
using Foodee.Application.Features.Mediator.Results.AboutResults;
using Foodee.Application.Interfaces;
using Foodee.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, List<GetAboutQueryResult>>
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetAboutQueryResult
            {
                AboutId= x.AboutId,
                CoverImageUrl= x.CoverImageUrl,
                Description= x.Description,
                Title= x.Title
            }).ToList();
        }
    }
}
