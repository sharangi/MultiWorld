using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiWorld.Models
{
    public class WarSimulationResultDto
    {
        public IEnumerable<TransformerDto> SurvivingAutobots
        {
            get
            {
                return _survivors?.Where(p => p.Allegiance == AllegianceType.Autobot);
            }
        }
        public IEnumerable<TransformerDto> SurvivingDecpticons
        {
            get
            {
                return _survivors?.Where(p => p.Allegiance == AllegianceType.Decepticon);
            }
        }

        private List<TransformerDto> _survivors;
        public WarSimulationResultDto(IEnumerable<Transformer> survivors)
        {
            _survivors = new List<TransformerDto>();
            foreach(var survivor in survivors)
            {
                _survivors.Add(new TransformerDto()
                {
                    Id = survivor.Id.ToString(),
                    Name = survivor.Name,
                    Allegiance = survivor.Allegiance,
                    Strength = survivor.Strength,
                    Intelligence = survivor.Intelligence,
                    Speed = survivor.Speed,
                    Endurance = survivor.Endurance,
                    Rank = survivor.Rank,
                    Courage = survivor.Courage,
                    Firepower = survivor.Firepower,
                    Skill = survivor.Skill,
                    OverallScore = survivor.GetScore()
                });
            }
        }
    }
}
