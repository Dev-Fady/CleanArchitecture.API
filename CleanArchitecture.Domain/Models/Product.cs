using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Models
{
    public class Product : NamedEntity
    {
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public double Quantity { get; set; }
        public int MinQuantity { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
