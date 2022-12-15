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
    public class ProvinceAPIController : ApiController
    {
        private ApplicationDbContext ctx;
        public ProvinceAPIController()
        {
            ctx = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
        }

        [Route("api/province/get")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var provinces = await ctx.Provinces.ToListAsync();
            return Ok(provinces);
        }

        [Route("api/province/post")]
        [HttpPost]
        public async Task<IHttpActionResult> PostProvince(Province province)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ctx.Provinces.Add(province);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
