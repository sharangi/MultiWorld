using MultiWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiWorld.Services
{
    public class BattleRules
    {
        public static readonly string Optimus = "Optimus".ToLower();
        public static readonly string Predaking = "Predaking".ToLower();

        public static bool OptimusVsPredakingNoSurvivorsRule(List<string> autobotNames, List<string> decepticonNames)
        {
            if ((autobotNames.Contains(Optimus) && decepticonNames.Contains(Predaking)) ||
                (autobotNames.Contains(Predaking) && decepticonNames.Contains(Optimus)))
            {
                return true;
            }
            return false;
        }
        public static List<Transformer> OptimusOrPredakingWinsByNameRule(Transformer a, Transformer b)
        {
            var survivors = new List<Transformer>();
            if (a.Name.ToLower() == Optimus || a.Name.ToLower() == Predaking)
            {
                survivors.Add(a);
            }
            if (b.Name.ToLower() == Optimus || b.Name.ToLower() == Predaking)
            {
                survivors.Add(b);
            }

            return survivors;
        }
        public static Transformer StrengthAndCourageRule(Transformer a, Transformer b)
        {
            if (((a.Strength - b.Strength) >= 3) && (b.Courage < 5))
            {
                return a;
            }
            else
            {
                if (((b.Strength - a.Strength) >= 3) && (a.Courage < 5))
                {
                    return b;
                }
            }
            return null;
        }
        public static Transformer SkillRule(Transformer a, Transformer b)
        {
            if (((a.Skill - b.Skill) >= 5))
            {
                return a;
            }
            else
            {
                if (((b.Skill - a.Skill) >= 5))
                {
                    return b;
                }
            }
            return null;
        }
        public static List<Transformer> ScoreRule(Transformer a, Transformer b)
        {
            var survivors = new List<Transformer>();
            if(a.GetScore() == b.GetScore())
            {
                survivors.Add(a);
                survivors.Add(b);
            }
            if (!survivors.Any())
            {
                var survivor = a.GetScore() > b.GetScore() ? a : b;
                if (survivor != null)
                    survivors.Add(survivor);
            }
            return survivors;
        }
    }
}
