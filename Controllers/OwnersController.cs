using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Controllers
{
    [Route("owner")]
    public class OwnersController : Controller
    {
        private PropertyDbContext _ctx { get; set; }
        public OwnersController(PropertyDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOne(int id)
        {
            Owner owner = await _ctx.Owners.FirstOrDefaultAsync(x => x.Id == id);
            if (owner is null)
            {
                return BadRequest("Entity with ID not found");
            }
            else
            {
                return Ok(await _ctx.Owners.FirstOrDefaultAsync(x => x.Id == id));
            }
        }
    }
}
