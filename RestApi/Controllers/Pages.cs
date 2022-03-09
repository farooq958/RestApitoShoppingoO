using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class Pages : ControllerBase
    {
        private readonly ShoppingoOcontext shoppingoOcontext;
        public Pages(ShoppingoOcontext shoppingoOcontext)
        {
            this.shoppingoOcontext = shoppingoOcontext;
        }
        [HttpGet]
        // /api/pages
        public async Task<ActionResult<IEnumerable<Page>>> GetPages()
        {
            return await shoppingoOcontext.Pages.OrderBy(x => x.Sorting).ToListAsync();

        }
        [HttpGet("{id}")]
        // /api/pages/id
        public async Task<ActionResult<Page>> GetPage(int id)
        {
          var pge= await shoppingoOcontext.Pages.FindAsync(id);

            if (pge==null)
            {
                return NotFound();
            }
            else
                return pge;
        }
        [HttpPut("{id}")]
        // /api/pages/id
        public async Task<ActionResult<Page>> PutPage(int id,Page page)
        {
            if (id != page.Id)
            {
                return BadRequest();
            }
         
            
                shoppingoOcontext.Entry(page).State = EntityState.Modified;
                await shoppingoOcontext.SaveChangesAsync();
            return NoContent();
            
        }
        [HttpPost]
        // /api/pages
        public async Task<ActionResult<Page>> PostPage( Page page)
        {

            shoppingoOcontext.Add(page);
            await shoppingoOcontext.SaveChangesAsync();
            return CreatedAtAction(nameof(PostPage),page);


        }
        [HttpDelete("{id}")]
        // /api/pages/id
        public async Task<ActionResult<Page>> DeletePage(int id)
        {
          var page = shoppingoOcontext.Pages.FindAsync(id);
            shoppingoOcontext.Remove(page);
            await shoppingoOcontext.SaveChangesAsync();
            return NoContent();

        }

    }
}
