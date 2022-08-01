using Microsoft.EntityFrameworkCore;


namespace RestApi.Model
{
    public class ShoppingoOcontext : DbContext
    {
        public ShoppingoOcontext( DbContextOptions<ShoppingoOcontext> options) : base(options)
        {
       } 
        
        public DbSet<Page> Pages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
