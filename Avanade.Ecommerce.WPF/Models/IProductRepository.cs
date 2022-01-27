using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Ecommerce.WPF.Models
{
    public interface IProductRepository
    {
        IList<Product> GetAll();
    }
}
