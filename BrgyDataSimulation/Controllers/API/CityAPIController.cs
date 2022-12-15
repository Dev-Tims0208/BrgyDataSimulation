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
    public class CityAPIController : ApiController
    {
        private ApplicationDbContext ctx;
        public CityAPIController()
        {
            ctx = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
        }

        [Route("api/city/get")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var city = await ctx.City.ToListAsync();
            return Ok(city);
        }

        [Route("api/city/post")]
        [HttpPost]
        public async Task<IHttpActionResult> PostCity(City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ctx.City.Add(city);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
