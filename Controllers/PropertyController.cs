using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Controllers
{
    [Route("property")]
    public class PropertyController : Controller
    {
        private PropertyDbContext _ctx;
        public PropertyController(PropertyDbContext ctx)
        {
            this._ctx = ctx;
        }
        // GET: PropertyController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> Index()
        {
            return await _ctx.Properties.ToListAsync();
        }

        // GET: Property/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Details(int id)
        {
            Property property = await _ctx.Properties.FirstOrDefaultAsync(x => x.Id == id);
            if(property is null)
            {
                return BadRequest("Entity with ID not found");
            }
            else
            {
                return Ok(await _ctx.Properties.FirstOrDefaultAsync(x => x.Id == id));
            }
        }

        // GET: PropertyController/Create
        [HttpPost]
        public async Task Create([FromBody] Property property)
        {
            await _ctx.Properties.AddAsync(property);
            await _ctx.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Property property = await _ctx.Properties.FirstOrDefaultAsync(x => x.Id == id);

            if(property is null)
            {
                return BadRequest("Entity with ID not found");
            }
            else
            {
                _ctx.Properties.Remove(property);
                await _ctx.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
