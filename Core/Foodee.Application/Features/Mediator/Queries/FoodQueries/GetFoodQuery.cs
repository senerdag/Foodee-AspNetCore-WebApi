using Foodee.Application.Features.Mediator.Results.FoodResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Queries.FoodQueries
{
    public class GetFoodQuery:IRequest<List<GetFoodQueryResult>>
    {
    }
}
