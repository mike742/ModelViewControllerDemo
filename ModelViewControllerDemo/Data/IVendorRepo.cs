using ModelViewControllerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelViewControllerDemo.Data
{
    public interface IVendorRepo
    {
        IEnumerable<Vendor> GetAll();
        Vendor GetById(int id);
        void Create(Vendor vendor);
    }
}
