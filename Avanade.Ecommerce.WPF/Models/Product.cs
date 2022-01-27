using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Ecommerce.WPF.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Description} - {Price}€";
        }
    }
}
