using Microsoft.AspNetCore.Mvc;
using MultiWorld.DAL;
using MultiWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransformersController : ControllerBase
    {
        private readonly MultiWorldDbContext _context;
        public TransformersController(MultiWorldDbContext context)
        {
            _context = context;
        }
        // GET api/Transformer/Autobots
        [HttpGet]
        [Route("Autobots")]
        public ActionResult<IEnumerable<TransformerDto>> GetAutobots()
        {
            return Ok(_context.Transformers.Where(p => p.Allegiance == AllegianceType.Autobot).OrderBy(p => p.Name));
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
            _context.Transformers.Add(transformer);
            _context.SaveChanges();

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
