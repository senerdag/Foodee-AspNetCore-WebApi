using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Dto.AboutDtos
{
    public class CreateAboutDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
