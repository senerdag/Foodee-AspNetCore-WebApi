using Foodee.Application.Features.Mediator.Results.CategoryResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Queries.CategoryQueries
{
    public class GetCategoryQuery:IRequest<List<GetCategoryQueryResult>>
    {
    }
}
