using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiWorld.Models;

namespace MultiWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransformersController : ControllerBase
    {
        // GET: api/Transformers
        [HttpGet]
        public IEnumerable<Transformer> Get()
        {
            return null;
        }

        // GET: api/Transformers/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(Guid id)
        {
            return "value";
        }

        // POST: api/Transformers
        [HttpPost]
        public void Post([FromBody] Transformer transformer)
        {
        }

        // PUT: api/Transformers/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Transformer transformer)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
