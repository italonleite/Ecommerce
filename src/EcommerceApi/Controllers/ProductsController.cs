using EcommerceApi.Infra;
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
        private readonly EcommerceDbContext _ecommerceDbContext;
        public ProductsController(EcommerceDbContext ecommerceDbContext)
        {
            _ecommerceDbContext = ecommerceDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _ecommerceDbContext.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _ecommerceDbContext.Products.SingleOrDefault(p => p.Id == id);
            if (product == null) 
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
