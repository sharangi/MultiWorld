using System;
using NUnit.Framework;
using MultiWorld.Models;
using MultiWorld.Services;

namespace MultiWorld.Tests.UnitTests
{
    public class BattleStrengthAndCourageRuleTests
    {
        [Test]
        public void Strength_4vs1_Courage_1vs4_A_Wins()
        {
            var a = new Transformer()
            {
                Id = Guid.NewGuid(),
                Strength = 4,
                Courage = 1
            };
            var b = new Transformer()
            {
                Id = Guid.NewGuid(),
                Strength = 1,
                Courage = 4
            };
            var survivor = BattleRules.StrengthAndCourageRule(a, b);
            Assert.IsNotNull(survivor);
            Assert.AreEqual(a.Id,survivor.Id);
            Assert.AreNotEqual(b.Id,survivor.Id);
        }
        [Test]
        public void Strength_4vs1_Courage_1vs5_NoOne_Wins()
        {
            var a = new Transformer()
            {
                Id = Guid.NewGuid(),
                Strength = 4,
                Courage = 1
            };
            var b = new Transformer()
            {
                Id = Guid.NewGuid(),
                Strength = 1,
                Courage = 5
            };
            var survivor = BattleRules.StrengthAndCourageRule(a, b);
            Assert.IsNull(survivor);
        }
        [Test]
        public void Strength_1vs5_Courage_4vs1_B_Wins()
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
                Strength = 4,
                Courage = 1
            };
            var survivor = BattleRules.StrengthAndCourageRule(a, b);
            Assert.IsNotNull(survivor);
            Assert.AreEqual(b.Id, survivor.Id);
            Assert.AreNotEqual(a.Id, survivor.Id);
        }
        [Test]
        public void Strength_1vs4_Courage_5vs1_NoOne_Wins()
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
                Strength = 4,
                Courage = 1
            };
            var survivor = BattleRules.StrengthAndCourageRule(a, b);
            Assert.IsNull(survivor);
        }

    }
}