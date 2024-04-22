using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Dto.FoodDtos
{
	public class ResultFoodDto
	{
		public int FoodId { get; set; }
		public int CategoryId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string CoverImageUrl { get; set; }
	}
}
