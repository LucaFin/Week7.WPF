using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Ecommerce.WPF.Models
{
    public class ProductRepositoryMock : IProductRepository
    {
        private IList<Product> products = new List<Product>()
        {
            new Product()
            {
                Name = "Smartphone",
                Description = "iPhone XR 128GB",
                Price = 450.45
            },
            new Product()
            {
                Name = "Borsa Gucci",
                Description = "Borsa in pelle",
                Price = 200.34
            }
        };
        public IList<Product> GetAll()
        {
            return products;
        }
    }
}
