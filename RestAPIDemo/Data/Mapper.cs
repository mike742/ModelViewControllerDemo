using RestAPIDemo.Models;
using RestAPIDemo.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIDemo.Data
{
    public class Mapper
    {
        public Product Map(ProductDto input)
        {
            return new Product {
                Name = input.Name,
                Price = input.Price
            };
        }

        public ProductDto Map(Product input)
        {
            return new ProductDto { 
                Name = input.Name,
                Price = input.Price
            };
        }
    }
}
