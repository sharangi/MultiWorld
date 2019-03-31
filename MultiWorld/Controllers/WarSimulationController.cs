using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiWorld.Models;
using MultiWorld.Services;

namespace MultiWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarSimulationController : ControllerBase
    {

        private readonly IWarSimulationService _warSimulationService;
        public WarSimulationController(IWarSimulationService warSimulationService)
        {
            _warSimulationService = warSimulationService;
        }
        // POST: api/WarSimulation
        [HttpPost]
        public ActionResult<WarSimulationResultDto> Post()
        {
            var survivors = _warSimulationService.SimulateWar();
            var result = new WarSimulationResultDto(survivors);
            return Ok(result);
        }
    }
}
