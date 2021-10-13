using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelViewControllerDemo.Data;
using ModelViewControllerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelViewControllerDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _repo;
        private readonly IVendorRepo _vendorRepo;

        public ProductController(IProductRepo repo, IVendorRepo vendorsRepo)
        {
            _repo = repo;
            _vendorRepo = vendorsRepo;
        }
        public IActionResult Index()
        {
            var vendors = _vendorRepo.GetAll().ToList();

            var product = _repo.GetAll()
                .Select(p => {
                    p.Vendor = vendors
                     .Where(v => v.V_code == p.V_code)
                     .FirstOrDefault() ?? new Vendor { V_name = "No name"};
                    return p;
                } );

            return View(product);
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

        public IActionResult Create()
        {
            var vendors = _vendorRepo.GetAll().ToList();

            ViewBag.Vendors = new SelectList(vendors, "V_code", "V_name");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            _repo.Create(product);
            return RedirectToAction("Index");
        }
    }
}
