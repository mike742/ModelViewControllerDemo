using Microsoft.AspNetCore.Mvc;
using ModelViewControllerDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelViewControllerDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _repo;

        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public IEnumerable<string> GetProductsByVendorId(int? id)
        {
            var res = _repo.GetAll().Where(p => p.V_code == id)
                .Select(p => p.P_descript + "\t" + p.P_Price + "<br />");

            if (res == null || res.Count() == 0)
            {
                return new List<string> { "No Product found" };
            }

            return res;
        }
    }
}
