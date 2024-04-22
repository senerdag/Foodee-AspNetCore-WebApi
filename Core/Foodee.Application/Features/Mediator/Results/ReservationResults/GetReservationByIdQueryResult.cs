using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Results.ReservationResults
{
    public class GetReservationByIdQueryResult
    {
        public int ReservationId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int People { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Message { get; set; }
    }
}
