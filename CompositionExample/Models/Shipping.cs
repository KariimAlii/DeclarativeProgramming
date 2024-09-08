using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionExample.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
        public int Amount { get; set; }
    }
}
