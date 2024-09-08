using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionExample.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public int Amount { get; set; }
    }
}
