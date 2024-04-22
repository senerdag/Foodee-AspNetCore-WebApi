using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Food> Foods { get; set; }
    }
}
