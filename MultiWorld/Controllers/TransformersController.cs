using Microsoft.AspNetCore.Mvc;
using MultiWorld.DAL;
using MultiWorld.Models;
using MultiWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransformersController : ControllerBase
    {
        private readonly ITransformerService _transformerService;
        public TransformersController(ITransformerService transformerService)
        {
            _transformerService = transformerService;
        }
        // GET api/Transformers/{id}/Score
        [HttpGet("{id}/Score")]
        public ActionResult<IEnumerable<TransformerDto>> GetScore(Guid id)
        {
            var score = _transformerService.GetTransformerScore(id);
            if (score == null)
                return NotFound("Score for Transformer with id " + id + " not found.");
            else
                return Ok(score);
        }
        // GET api/Transformers/Autobots
        [HttpGet]
        [Route("Autobots")]
        public ActionResult<IEnumerable<TransformerDto>> GetAutobots()
        {
            return Ok(_transformerService.GetAllAutobots());
        }
        // GET api/Transformers/Decepticons
        [HttpGet]
        [Route("Decepticons")]
        public ActionResult<IEnumerable<TransformerDto>> GetDecepticons()
        {
            return Ok(_transformerService.GetAllDecepticons());
        }

        // GET: api/Transformers/{id}
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<TransformerDto> Get(Guid id)
        {
            return Ok(_transformerService.GetTransformerById(id));
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

            _transformerService.Add(transformer);

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
            var transformer = _transformerService.GetTransformerById(id);
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

            _transformerService.Update(transformer);

            return Ok(transformerDto);
        }

        // DELETE: api/Transformers/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var transformer = _transformerService.GetTransformerById(id);
            if (transformer == null)
            {
                return NotFound("Transformer with id " + id + " not found.");
            }
            _transformerService.Remove(transformer);
            return Ok("Transformer with id "+id+" removed.");
        }
    }
}
