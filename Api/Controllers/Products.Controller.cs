
using Api.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        //actionResult é o método
        //n retorna string
        //ele também funciona sem o Task e await/async (esses funcionam juntos)
        //existem dois metodos ToList e ToListAsync
        //do jeito que está é o mais recomendado: método asssincrono:só realiza quando carregar
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await  _context.Products.ToListAsync();//esse Products aqui tem a ver com o DBcontext lá no StoreContext
            return products;
        }


        [HttpGet("product/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return  await _context.Products.FindAsync(id);//retorna o produto indivual do BD criado
            //.Products. é a chamada do dbcontext
        }
    }
}