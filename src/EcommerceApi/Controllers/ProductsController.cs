using EcommerceApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Controllers
{
    [Route ("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public List<Product> _produtcs = new List<Product>
        {
            new Product(1, "nootebook", 2200),
            new Product(2, "mouse", 200),
            new Product(3, "teclado", 150)
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_produtcs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //SingleOrDefault - 
            //FirstOrDefault - primeiro item
            var product = _produtcs.SingleOrDefault(p => p.Id == id);
            if (product == null) 
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
