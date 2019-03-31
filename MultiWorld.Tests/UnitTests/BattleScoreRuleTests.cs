using MultiWorld.Models;
using MultiWorld.Services;
using NUnit.Framework;
using System;

namespace MultiWorld.Tests.UnitTests
{
    public class BattleScoreRuleTests
    {
        [Test]
        public void Score_6vs6_Both_Win()
        {
            var a = new Transformer()
            {
                Id = Guid.NewGuid(),
                Strength = 1,
                Courage = 5
            };
            var b = new Transformer()
            {
                Id = Guid.NewGuid(),
                Strength = 1,
                Courage = 5
            };
            var survivors = BattleRules.ScoreRule(a, b);
            Assert.IsTrue(survivors.Contains(a));
            Assert.IsTrue(survivors.Contains(b));
        }
        [Test]
        public void Score_6vs5_A_Wins()
        {
            var a = new Transformer()
            {
                Id = Guid.NewGuid(),
                Strength = 1,
                Courage = 5
            };
            var b = new Transformer()
            {
                Id = Guid.NewGuid(),
                Strength = 1,
                Courage = 4
            };
            var survivors = BattleRules.ScoreRule(a, b);
            Assert.IsTrue(survivors.Contains(a));
            Assert.IsFalse(survivors.Contains(b));
        }
        [Test]
        public void Score_5vs6_B_Wins()
        {
            var a = new Transformer()
            {
                Id = Guid.NewGuid(),
                Strength = 1,
                Courage = 4
            };
            var b = new Transformer()
            {
                Id = Guid.NewGuid(),
                Strength = 1,
                Courage = 5
            };
            var survivors = BattleRules.ScoreRule(a, b);
            Assert.IsTrue(survivors.Contains(b));
            Assert.IsFalse(survivors.Contains(a));
        }
    }
}