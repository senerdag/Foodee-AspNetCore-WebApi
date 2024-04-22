using Foodee.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Commands.CategoryCommands
{
    public class UpdateCategoryCommand:IRequest
    {
        public int CategoryId { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
