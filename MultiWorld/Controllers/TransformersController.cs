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
        // GET api/Transformer/Autobots
        [HttpGet]
        [Route("Autobots")]
        public ActionResult<IEnumerable<TransformerDto>> GetAutobots()
        {
            return Ok();
        }
        // GET api/Transformer/Decepticons
        [HttpGet]
        [Route("Decepticons")]
        public ActionResult<IEnumerable<TransformerDto>> GetDecepticons()
        {
            return Ok();
        }

        // GET: api/Transformers/{id}
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<TransformerDto> Get(Guid id)
        {
            return Ok();
        }

        // POST: api/Transformers
        [HttpPost]
        public ActionResult<TransformerDto> Post([FromBody] TransformerDto transformerDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            var transformer = new Transformer()
            {
                Name = transformerDto.Name,
                Allegiance = transformerDto.Allegiance,
                Strength = transformerDto.Strength,
                Intelligence = transformerDto.Intelligence,
                Speed = transformerDto.Speed,
                Endurance = transformerDto.Endurance,
                Rank = transformerDto.Rank,
                Courage = transformerDto.Courage,
                Firepower = transformerDto.Firepower,
                Skill = transformerDto.Skill
            };
            transformerDto.Id = transformer.Id.ToString();
            return Ok(transformerDto);
        }

        // PUT: api/Transformers/{id}
        [HttpPut("{id}")]
        public ActionResult<TransformerDto> Put(Guid id, [FromBody]TransformerDto transformerDtor)
        {
            return Ok();
        }

        // DELETE: api/Transformers/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            return Ok();
        }
    }
}
