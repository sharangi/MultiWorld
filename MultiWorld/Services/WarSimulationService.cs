using MultiWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiWorld.Services
{
    public interface IWarSimulationService
    {
        IEnumerable<Transformer> SimulateWar();
    }
    public class WarSimulationService : IWarSimulationService
    {
        private readonly ITransformerService _transformerService;

        public WarSimulationService(ITransformerService transformerService)
        {
            _transformerService = transformerService;
        }

        public IEnumerable<Transformer> SimulateWar()
        {
            var survivers = new List<Transformer>();

            //Check for no-survivor conditions
            var autobotNames = _transformerService.GetAllAutobots().Select(p => p.Name.ToLower()).ToList();
            var decepticonNames = _transformerService.GetAllDecepticons().Select(p => p.Name.ToLower()).ToList();
            if(BattleRules.OptimusVsPredakingNoSurvivorsRule(autobotNames,decepticonNames))
            {
                return survivers;
            }

            //This section of the war will have survivors
            var rankedAutobots = _transformerService.GetAllAutobots().OrderByDescending(p => p.Rank).ToList();
            var rankedDecepticons = _transformerService.GetAllDecepticons().OrderByDescending(p => p.Rank).ToList();
            var AreThereMoreAutobots = rankedAutobots.Count() > rankedDecepticons.Count();
            var minOfTheTwoGroups = AreThereMoreAutobots ? rankedDecepticons.Count() : rankedAutobots.Count();

            //One-to-one battles 
            var i = 0;
            while (i < minOfTheTwoGroups)
            {
                var survivorsOfDuel = OneOnOneBattle(rankedAutobots[i], rankedDecepticons[i]);
                if (survivorsOfDuel != null)
                {
                    survivers.AddRange(survivorsOfDuel);
                }
                i++;
            }

            //Add unpaired transformers as survivors
            if (AreThereMoreAutobots)
            {
                for (; i < rankedAutobots.Count(); i++)
                {
                    survivers.Add(rankedAutobots[i]);
                }
            }
            else
            {
                for (; i < rankedAutobots.Count(); i++)
                {
                    survivers.Add(rankedDecepticons[i]);
                }
            }           
            return survivers;
        }
        private List<Transformer> OneOnOneBattle(Transformer a, Transformer b)
        {
            var survivors = BattleRules.OptimusOrPredakingWinsByNameRule(a, b);
            if (!survivors.Any())
            {
                var survivor = BattleRules.StrengthAndCourageRule(a, b);
                if (survivor != null)
                    survivors.Add(survivor);
            }
            if (!survivors.Any())
            {
                var survivor = BattleRules.StrengthAndCourageRule(b, a);
                if (survivor != null)
                    survivors.Add(survivor);
            }
            if (!survivors.Any())
            {
                var survivor = BattleRules.SkillRule(a, b);
                if (survivor != null)
                    survivors.Add(survivor);
            }
            if (!survivors.Any())
            {
                var survivor = BattleRules.SkillRule(b, a);
                if (survivor != null)
                    survivors.Add(survivor);
            }
            if (!survivors.Any())
            {
                survivors.AddRange(BattleRules.ScoreRule(a, b));
            }
            return survivors;
        }
    }
}
