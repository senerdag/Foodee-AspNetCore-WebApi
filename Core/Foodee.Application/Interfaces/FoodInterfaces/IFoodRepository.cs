using Foodee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Interfaces.FoodInterfaces
{
	public interface IFoodRepository
	{
		public List<Food> GetCategoryWithFoods();
		public List<Food> GetLast6Food();

	}
}
