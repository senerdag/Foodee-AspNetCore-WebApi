using Foodee.Application.Features.Mediator.Queries.DescriptionQueries;
using Foodee.Application.Features.Mediator.Results.DescriptionResults;
using Foodee.Application.Interfaces;
using Foodee.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Handlers.DescriptionHandlers
{
    public class GetDescriptionByIdQueryHandler : IRequestHandler<GetDescriptionByIdQuery, GetDescriptionByIdQueryResult>
    {
        private readonly IRepository<Description> _repository;

        public GetDescriptionByIdQueryHandler(IRepository<Description> repository)
        {
            _repository = repository;
        }

        public async Task<GetDescriptionByIdQueryResult> Handle(GetDescriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetDescriptionByIdQueryResult
            {
                DescriptionId = values.DescriptionId,
                MainDescription = values.MainDescription,
                Name = values.Name
            };
        }
    }
}
