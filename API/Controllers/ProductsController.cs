using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Interfaces;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public  ProductsController(IProductRepository repo)
        {
            _repo=repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products =await _repo.GetProductsAsync();
            return Ok(products);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            return await _repo.GetProductByIdAsync(id);

        }


    }
}