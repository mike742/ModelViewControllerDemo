using Microsoft.AspNetCore.Mvc;
using ModelViewControllerDemo.Data;
using ModelViewControllerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelViewControllerDemo.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorRepo _repo;

        public VendorController(IVendorRepo repo)
        {
            _repo = repo;
        }
        public ActionResult<IEnumerable<Vendor>> Index()
        {
            var vendors = _repo.GetAll();
            return View(vendors);
        }
    }
}
