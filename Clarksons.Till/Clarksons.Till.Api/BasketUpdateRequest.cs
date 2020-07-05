using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clarksons.Till.Api
{
    public class BasketUpdateRequest
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
//dto