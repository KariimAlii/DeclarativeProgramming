using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionExample.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Item> Items { get; set; }
    }
    public class Item
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int UnitPrice { get; set; }
    }
}
