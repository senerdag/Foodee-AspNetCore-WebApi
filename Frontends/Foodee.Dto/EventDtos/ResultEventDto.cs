using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Dto.EventDtos
{
	public class ResultEventDto
	{
		public int EventId { get; set; }
		public string Title { get; set; }
		public DateTime EventDate { get; set; }
		public string Description { get; set; }
	}
}
