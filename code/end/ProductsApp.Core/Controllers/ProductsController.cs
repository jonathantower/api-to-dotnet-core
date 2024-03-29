﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProductsApp.Core.Config;
using ProductsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProductsApp.Core.Controllers
{
    //[Route("api/[controller]"), ApiController]
    public class ProductsController : ApiController
    {
        private readonly ConnectionStringsConfig _options;

        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        public ProductsController(IOptions<ConnectionStringsConfig> options) 
        {
            _options = options.Value;
        }

        //[HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        //[HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
