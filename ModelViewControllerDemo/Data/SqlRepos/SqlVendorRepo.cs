using ModelViewControllerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelViewControllerDemo.Data.SqlRepos
{
    public class SqlVendorRepo : IVendorRepo
    {
        private readonly AppDbContext _context;

        public SqlVendorRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Vendor vendor)
        {
            if (vendor == null)
                throw new ArgumentException(nameof(vendor));

            _context.Vendors.Add(vendor);
            SaveChanges();
        }

        public IEnumerable<Vendor> GetAll()
        {
            return _context.Vendors.ToList();
        }

        public Vendor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
