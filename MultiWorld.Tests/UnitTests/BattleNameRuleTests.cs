using MultiWorld.Models;
using MultiWorld.Services;
using NUnit.Framework;

namespace MultiWorld.Tests.UnitTests
{
    public class BattleNameRuleTests
    {
        [Test]
        public void Optimus_Survives_Vs_NonOptimusNonPredaking()
        {
            var a = new Transformer()
            {
                Name = BattleRules.Optimus
            };
            var b = new Transformer()
            {
                Name = "RandomName"
            };
            var survivors = BattleRules.OptimusOrPredakingWinsByNameRule(a, b);
            Assert.IsTrue(survivors.Contains(a));
            Assert.IsFalse(survivors.Contains(b));
        }
        [Test]
        public void Predaking_SurvivesVsNonOptimusNonPredaking()
        {
            var a = new Transformer()
            {
                Name = BattleRules.Predaking
            };
            var b = new Transformer()
            {
                Name = "RandomName"
            };
            var survivors = BattleRules.OptimusOrPredakingWinsByNameRule(a, b);
            Assert.IsTrue(survivors.Contains(a));
            Assert.IsFalse(survivors.Contains(b));
        }
        [Test]
        public void OptimusVsPredaking_Both_Survive_Battle()
        {
            var a = new Transformer()
            {
                Name = BattleRules.Optimus
            };
            var b = new Transformer()
            {
                Name = BattleRules.Predaking
            };
            var survivors = BattleRules.OptimusOrPredakingWinsByNameRule(a, b);
            Assert.IsTrue(survivors.Contains(a));
            Assert.IsTrue(survivors.Contains(b));
        }
    }
}