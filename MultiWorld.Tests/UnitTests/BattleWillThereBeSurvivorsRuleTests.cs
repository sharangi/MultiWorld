using MultiWorld.Models;
using MultiWorld.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace MultiWorld.Tests.UnitTests
{
    public class BattleWillThereBeSurvivorsRuleTests
    {
        [Test]
        public void Optimus_vs_Predaking_No_Survivors()
        {
            List<string> autobotNames = new List<string>() { "Random",BattleRules.Optimus};
            List< string > decepticonNames = new List<string>() { "Random", BattleRules.Predaking };
            var canThereBeSurvivors = BattleRules.CanThereBeSurvivorsRule(autobotNames,decepticonNames);
            Assert.IsFalse(canThereBeSurvivors);
        }
        [Test]
        public void Predaking_vs_Optimus_No_Survivors()
        {
            List<string> autobotNames = new List<string>() { "Random", BattleRules.Predaking };
            List<string> decepticonNames = new List<string>() { "Random", BattleRules.Optimus };
            var canThereBeSurvivors = BattleRules.CanThereBeSurvivorsRule(autobotNames, decepticonNames);
            Assert.IsFalse(canThereBeSurvivors);
        }
        [Test]
        public void Optimus_vs_Optimus_Maybe_Survivors()
        {
            List<string> autobotNames = new List<string>() { "Random", BattleRules.Optimus };
            List<string> decepticonNames = new List<string>() { "Random", BattleRules.Optimus };
            var canThereBeSurvivors = BattleRules.CanThereBeSurvivorsRule(autobotNames, decepticonNames);
            Assert.IsTrue(canThereBeSurvivors);
        }
        [Test]
        public void Predaking_vs_Predaking_Maybe_Survivors()
        {
            List<string> autobotNames = new List<string>() { "Random", BattleRules.Predaking };
            List<string> decepticonNames = new List<string>() { "Random", BattleRules.Predaking };
            var canThereBeSurvivors = BattleRules.CanThereBeSurvivorsRule(autobotNames, decepticonNames);
            Assert.IsTrue(canThereBeSurvivors);
        }
    }
}