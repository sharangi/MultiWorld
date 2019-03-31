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
        private readonly ITransformerRepository _transformerRepository;
        public TransformersController(MultiWorldDbContext context, ITransformerRepository transformerRepository)
        {
            _context = context;
            _transformerRepository = transformerRepository;
        }
        // GET api/Transformer/Autobots
        [HttpGet]
        [Route("Autobots")]
        public ActionResult<IEnumerable<TransformerDto>> GetAutobots()
        {
            return Ok(_transformerRepository.GetAll().Where(p => p.Allegiance == AllegianceType.Autobot).OrderBy(p => p.Name));
        }
        // GET api/Transformer/Decepticons
        [HttpGet]
        [Route("Decepticons")]
        public ActionResult<IEnumerable<TransformerDto>> GetDecepticons()
        {
            return Ok(_transformerRepository.GetAll().Where(p => p.Allegiance == AllegianceType.Decepticon).OrderBy(p => p.Name));
        }

        // GET: api/Transformers/{id}
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<TransformerDto> Get(Guid id)
        {
            return Ok(_transformerRepository.GetAll().Where(p => p.Id == id).FirstOrDefault());
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
        public ActionResult<TransformerDto> Put(Guid id, [FromBody]TransformerDto transformerDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            var guidFromRequestBody = new Guid();
            if(!Guid.TryParse(transformerDto.Id, out guidFromRequestBody))
            {
                BadRequest("Id invalid in message request body");
            }
            if (guidFromRequestBody != id)
            {
                BadRequest("Id in the URL does not match Id specified in the body");
            }
            var transformer = _context.Transformers.Where(p => p.Id == id).FirstOrDefault();
            if (transformer == null)
            {
                return NotFound("Transformer with id " + id + " not found.");
            }
            transformer.Name = transformerDto.Name;
            transformer.Allegiance = transformerDto.Allegiance;
            transformer.Strength = transformerDto.Strength;
            transformer.Intelligence = transformerDto.Intelligence;
            transformer.Speed = transformerDto.Speed;
            transformer.Endurance = transformerDto.Endurance;
            transformer.Rank = transformerDto.Rank;
            transformer.Courage = transformerDto.Courage;
            transformer.Firepower = transformerDto.Firepower;
            transformer.Skill = transformerDto.Skill;
            transformer.LastUpdateTime = DateTime.UtcNow;

            _context.Transformers.Update(transformer);
            _context.SaveChanges();
            return Ok(transformerDto);
        }

        // DELETE: api/Transformers/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var transformer = _context.Transformers.Where(p => p.Id == id).FirstOrDefault();
            if (transformer == null)
            {
                return NotFound("Transformer with id " + id + " not found.");
            }
            _context.Transformers.Remove(transformer);
            _context.SaveChanges();
            return Ok("Transformer with id "+id+" removed.");
        }
    }
}
