using Foodee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Results.FoodResults
{
	public class GetCategoryWithFoodsQueryResult
	{
		public int FoodId { get; set; }
		public int CategoryId { get; set; }
		public int FoodCategoryId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string CoverImageUrl { get; set; }
		public string Icon { get; set; }
		public string CategoryName { get; set; }
	}
}
