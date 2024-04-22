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
    public class GetContactInfoByIdQueryHandler : IRequestHandler<GetContactInfoByIdQuery, GetContactInfoByIdQueryResult>
    {
        private readonly IRepository<ContactInfo> _repository;

        public GetContactInfoByIdQueryHandler(IRepository<ContactInfo> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactInfoByIdQueryResult> Handle(GetContactInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetContactInfoByIdQueryResult
            {
                ContactInfoId = values.ContactInfoId,
                Icon=values.Icon,
                Description = values.Description,
                Name = values.Name
            };
        }
    }
}
