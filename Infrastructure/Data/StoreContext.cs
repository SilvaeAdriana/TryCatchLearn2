
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class StoreContext : DbContext
    {
                //consturtor
        //options se refere a connection string
        //cria uma instancia do DbContext
        // public StoreContext(DbContextOptions options) : base(options)
        // {
        // }

        //com a criacao das pastas
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }


        //Products é uma entidade com base na classe Product
        public DbSet<Product> Products {get; set; }  //set de dados chamado Products(que é o controller) de Product.cs
       
    }
        
    }
