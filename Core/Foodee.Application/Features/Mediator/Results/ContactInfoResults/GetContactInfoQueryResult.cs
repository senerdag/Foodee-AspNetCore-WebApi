using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Results.ContactInfoResults
{
    public class GetContactInfoQueryResult
    {
        public int ContactInfoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
