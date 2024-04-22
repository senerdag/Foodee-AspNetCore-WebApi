using Foodee.Application.Interfaces.FoodInterfaces;
using Foodee.Domain.Entities;
using Foodee.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Persistence.Repositories.FoodRepositories
{
	public class FoodRepository : IFoodRepository
	{
		private readonly FoodeeContext _context;

		public FoodRepository(FoodeeContext context)
		{
			_context = context;
		}

		public List<Food> GetCategoryWithFoods()
		{
			var values= _context.Foods.Include(x => x.Category).ToList();
			return values;
		}

		public List<Food> GetLast6Food()
		{
			var values= _context.Foods.OrderByDescending(x=>x.FoodId).Take(6).ToList();
			return values;
		}
	}
}
