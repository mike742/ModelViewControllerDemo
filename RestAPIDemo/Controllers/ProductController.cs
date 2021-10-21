using Microsoft.AspNetCore.Mvc;
using RestAPIDemo.Data;
using RestAPIDemo.Models;
using RestAPIDemo.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContexxt _context;
        private readonly Mapper _mapper = new Mapper();
    
        public ProductController(AppDbContexxt context)
        {
            _context = context;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(_context.Products.ToList());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var prod = _context.Products.FirstOrDefault(p => p.Id == id);

            if (prod != null)
            {
                return Ok(prod);
            }
            return NotFound();
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post(ProductDto value)
        {
            Product prodToAdd = _mapper.Map(value);

            _context.Add(prodToAdd);
            _context.SaveChanges();
            
            return Ok();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, ProductDto value)
        {
            var prodFromDb = _context.Products
                .FirstOrDefault(p => p.Id == id);

            if (prodFromDb == null) return NotFound();

            prodFromDb.Name = value.Name;
            prodFromDb.Price = value.Price;

            // _context.Update(prodFromDb);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var prodFromDb = _context.Products
                .FirstOrDefault(p => p.Id == id);

            if (prodFromDb == null) return NotFound();

            _context.Products.Remove(prodFromDb);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
