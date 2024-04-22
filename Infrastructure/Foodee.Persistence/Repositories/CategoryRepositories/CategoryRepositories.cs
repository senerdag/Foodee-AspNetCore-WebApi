using Foodee.Application.Interfaces.CategoryInterfaces;
using Foodee.Domain.Entities;
using Foodee.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Persistence.Repositories.CategoryRepositories
{
	public class CategoryRepositories : ICategoryRepository
	{
		private readonly FoodeeContext _context;

		public CategoryRepositories(FoodeeContext context)
		{
			_context = context;
		}

		

		public List<Category> GetLastFourCategory()
		{
			var values = _context.Categories.OrderByDescending(x=>x.CategoryId).Take(4).ToList();
			return values;
		}
	}
}
