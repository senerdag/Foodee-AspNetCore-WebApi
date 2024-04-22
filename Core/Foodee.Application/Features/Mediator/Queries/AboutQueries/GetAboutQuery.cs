using Foodee.Application.Features.Mediator.Results.AboutResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Queries.AboutQueries
{
    public class GetAboutQuery:IRequest<List<GetAboutQueryResult>>
    {
    }
}
