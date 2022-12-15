using BrgyDataSimulation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BrgyDataSimulation.Controllers.API
{
    public class BarangayAPIController : ApiController
    {
        private ApplicationDbContext ctx;
        public BarangayAPIController()
        {
            ctx = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
        }

        [Route("api/barangay/get")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var brgy = await ctx.Barangays.Include(x => x.City).ToListAsync();
            return Ok(brgy);
        }

        [Route("api/barangay/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var brgy = await ctx.Barangays.Include(x => x.City).SingleOrDefaultAsync(x => x.Id == id);
            return Ok(brgy);
        }

        [Route("api/barangay/post")]
        [HttpPost]
        public async Task<IHttpActionResult> PostBarangay(Barangay barangay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ctx.Barangays.Add(barangay);
            await ctx.SaveChangesAsync();
            return Ok();
        }

        [Route("api/barangay/put/{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> PutBarangay(int id, Barangay barangay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var brgy = await ctx.Barangays.SingleOrDefaultAsync(x => x.Id == id);
            if (brgy == null)
            {
                return NotFound();
            }
            brgy.Name = barangay.Name;
            brgy.CityId = barangay.CityId;
            brgy.Population = barangay.Population;
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
