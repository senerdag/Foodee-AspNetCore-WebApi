﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Dto.QuoteDtos
{
    public class UpdateQuoteDto
    {
        public int QuoteId { get; set; }
        public string PersonName { get; set; }
        public string Description { get; set; }
    }
}
