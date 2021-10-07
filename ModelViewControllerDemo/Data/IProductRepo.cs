using ModelViewControllerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelViewControllerDemo.Data
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAll();
        Product GetById(string id);
    }
}
