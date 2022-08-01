using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ProductController : Controller
    {
        private readonly ShoppingoOcontext shoppingoOcontext;
        public ProductController(ShoppingoOcontext shoppingoOcontext)
        {
            this.shoppingoOcontext = shoppingoOcontext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> getallproducts()
        {
            //include is eager loading techninque not best but better best approach >>explicit loading

            var products = await shoppingoOcontext.Products.Include(shoppingoOcontext=> shoppingoOcontext.Category).ToListAsync(); 

            return  products;
        }
        [HttpGet("{id}")]
        // /api/product/id
        public async  Task<ActionResult<Product>> GetProduct(int id)
        {
            var prodct =   shoppingoOcontext.Products
                .Include(shoppingoOcontext => shoppingoOcontext.Category).Where(shoppingoOcontext=>shoppingoOcontext.Id==id).FirstOrDefault();

            if (prodct==null)
            { 
                return NotFound();
            }
            else
                return prodct;
        }


    }
}
