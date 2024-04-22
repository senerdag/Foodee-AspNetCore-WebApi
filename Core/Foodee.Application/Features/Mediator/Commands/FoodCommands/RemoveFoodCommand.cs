using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Commands.FoodCommands
{
    public class RemoveFoodCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveFoodCommand(int id)
        {
            Id = id;
        }
    }
}
