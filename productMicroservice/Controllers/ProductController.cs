using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productMicroservice.Models;
using productMicroservice.Repositories;
using System.Transactions;

namespace productMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productRepository.InsertProduct(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

                [HttpPut]
                public IActionResult Update([FromBody] Product product)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    // Ensure that the product being updated has the correct ID


                    // Check if the product with the specified ID exists
                    /*var existingProduct = _productRepository.GetProductById(product.Id);
                    if (existingProduct == null)
                    {
                        return NotFound("Product not found.");
                    }*/

                    // Update the product
                   _productRepository.UpdateProduct(product);


            return Ok();
                }

    }
}
