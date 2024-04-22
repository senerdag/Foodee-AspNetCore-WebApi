using Foodee.Application.Features.Mediator.Queries.ContactInfoQueries;
using Foodee.Application.Features.Mediator.Results.ContactInfoResults;
using Foodee.Application.Interfaces;
using Foodee.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Handlers.ContactInfoHandlers
{
    public class GetContactInfoQueryHandler : IRequestHandler<GetContactInfoQuery, List<GetContactInfoQueryResult>>
    {
        private readonly IRepository<ContactInfo> _repository;

        public GetContactInfoQueryHandler(IRepository<ContactInfo> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactInfoQueryResult>> Handle(GetContactInfoQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetContactInfoQueryResult
            {
                ContactInfoId = x.ContactInfoId,
                Icon=x.Icon,
                Description = x.Description,
                Name=x.Name
            }).ToList();
        }
    }
}
