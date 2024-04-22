using Foodee.Application.Features.Mediator.Results.EventResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Queries.EventQueries
{
    public class GetEventQuery:IRequest<List<GetEventQueryResult>>
    {
    }
}
