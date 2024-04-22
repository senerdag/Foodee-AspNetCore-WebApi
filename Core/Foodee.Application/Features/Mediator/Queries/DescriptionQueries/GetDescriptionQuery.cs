using Foodee.Application.Features.Mediator.Results.DescriptionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Queries.DescriptionQueries
{
    public class GetDescriptionQuery:IRequest<List<GetDescriptionQueryResult>>
    {
    }
}
