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
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContexxt _context;
        // GET: OrdersController

        public OrdersController(AppDbContexxt context)
        {
            _context = context;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult Get()
        {
            var orders = _context.Orders
                .Select(o => new OrderReadDto { 
                    Id = o.Id,
                    Name = o.Name,
                    Date = o.Date,
                    Products = _context.OrderProducts
                        .Where(op => op.OrderId == o.Id)
                        .Select(c => new ProductReadDto { 
                            Id = c.Product.Id,
                            Name = c.Product.Name,
                            Price = c.Product.Price
                        }  ).ToList()
                })
                .ToList();

            return Ok(orders);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var order = _context.Orders
                .Where(o => o.Id == id)
                .Select(o => new OrderReadDto
                {
                    Id = o.Id,
                    Name = o.Name,
                    Date = o.Date,
                    Products = _context.OrderProducts
                        .Where(op => op.OrderId == o.Id)
                        .Select(c => new ProductReadDto
                        {
                            Id = c.Product.Id,
                            Name = c.Product.Name,
                            Price = c.Product.Price
                        }).ToList()
                })
                .FirstOrDefault();

            if (order == null)
            {
                return NotFound($"Order with {id} doen't exist.");
            }

            return Ok(order);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult Post(OrderWriteDto value)
        {
            Order orderToAdd = new Order
            {
                Name = value.Name,
                Date = value.Date
            };

            _context.Orders.Add(orderToAdd);
            _context.SaveChanges();

            foreach (var id in value.ProductIds)
            {
                OrderProducts op = new OrderProducts { 
                    OrderId = orderToAdd.Id,
                    ProductId = id
                };

                _context.OrderProducts.Add(op);
            }

            _context.SaveChanges();

            return NoContent();
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
