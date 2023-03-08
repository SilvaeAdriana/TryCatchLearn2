using System.Collections.Generic;//não esquecer de importar o generics

using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public IProductRepository _repo;
       
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        //chamada dos metodos do repositorio injetado
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);
        }


        [HttpGet("product/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return  await _repo.GetProductByIdAsync(id);
        }
    }
}