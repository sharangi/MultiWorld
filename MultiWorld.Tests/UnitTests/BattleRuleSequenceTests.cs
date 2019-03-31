using System;
using NUnit.Framework;
using MultiWorld.Models;
using MultiWorld.Services;

namespace MultiWorld.Tests.UnitTests
{
    public class BattleRuleSequenceTests
    {
        [Test]
        public void Name_StrengthAndCourage_A_Wins()
        {
            var a = new Transformer()
            {                
                Id = Guid.NewGuid(),
                Name = "Random",
                Strength = 4,
                Courage = 1
            };
            var b = new Transformer()
            {                
                Id = Guid.NewGuid(),
                Name = "Random",
                Strength = 1,
                Courage = 4
            };
            var survivors = WarSimulationService.OneOnOneBattle(a,b);
            Assert.IsNotNull(survivors);
            Assert.IsTrue(survivors.Contains(a));
            Assert.IsFalse(survivors.Contains(b));
        }
        [Test]
        public void Name_StrengthAndCourage_B_Wins()
        {
            var a = new Transformer()
            {
                Id = Guid.NewGuid(),
                Name = "Random",
                Strength = 1,
                Courage = 4

            };
            var b = new Transformer()
            {
                Id = Guid.NewGuid(),
                Name = "Random",
                Strength = 4,
                Courage = 1
            };
            var survivors = WarSimulationService.OneOnOneBattle(a, b);
            Assert.IsNotNull(survivors);
            Assert.IsTrue(survivors.Contains(b));
            Assert.IsFalse(survivors.Contains(a));
        }
        [Test]
        public void Name_StrengthAndCourage_Skill_A_Wins()
        {
            var a = new Transformer()
            {
                Id = Guid.NewGuid(),
                Name = "Random",
                Strength = 1,
                Courage = 5,
                Skill = 6
            };
            var b = new Transformer()
            {
                Id = Guid.NewGuid(),
                Name = "Random",
                Strength = 4,
                Courage = 1,
                Skill = 1
            };
            var survivors = WarSimulationService.OneOnOneBattle(a, b);
            Assert.IsNotNull(survivors);
            Assert.IsTrue(survivors.Contains(a));
            Assert.IsFalse(survivors.Contains(b));
        }
        [Test]
        public void Name_StrengthAndCourage_Skill_B_Wins()
        {
            var a = new Transformer()
            {
                Id = Guid.NewGuid(),
                Name = "Random",
                Strength = 1,
                Courage = 5,
                Skill = 1
            };
            var b = new Transformer()
            {
                Id = Guid.NewGuid(),
                Name = "Random",
                Strength = 4,
                Courage = 1,
                Skill = 6
            };
            var survivors = WarSimulationService.OneOnOneBattle(a, b);
            Assert.IsNotNull(survivors);
            Assert.IsTrue(survivors.Contains(b));
            Assert.IsFalse(survivors.Contains(a));
        }
        [Test]
        public void Name_StrengthAndCourage_Skill_Score_A_Wins()
        {
            var a = new Transformer()
            {
                Id = Guid.NewGuid(),
                Name = "Random",
                Strength = 1,
                Courage = 5,
                Skill = 5
            };
            var b = new Transformer()
            {
                Id = Guid.NewGuid(),
                Name = "Random",
                Strength = 4,
                Courage = 1,
                Skill = 1
            };
            var survivors = WarSimulationService.OneOnOneBattle(a, b);
            Assert.IsNotNull(survivors);
            Assert.IsTrue(survivors.Contains(a));
            Assert.IsFalse(survivors.Contains(b));
        }
        [Test]
        public void Name_StrengthAndCourage_Skill_Score_B_Wins()
        {
            var a = new Transformer()
            {
                Id = Guid.NewGuid(),
                Name = "Random",
                Strength = 1,
                Courage = 5,
                Skill = 1
            };
            var b = new Transformer()
            {
                Id = Guid.NewGuid(),
                Name = "Random",
                Strength = 4,
                Courage = 1,
                Skill = 5
            };
            var survivors = WarSimulationService.OneOnOneBattle(a, b);
            Assert.IsNotNull(survivors);
            Assert.IsTrue(survivors.Contains(b));
            Assert.IsFalse(survivors.Contains(a));
        }
        [Test]
        public void Name_StrengthAndCourage_Skill_Score_Both_Survive()
        {
            var a = new Transformer()
            {
                Id = Guid.NewGuid(),
                Name = "Random",
                Strength = 1,
                Courage = 5,
                Skill = 1
            };
            var b = new Transformer()
            {
                Id = Guid.NewGuid(),
                Name = "Random",
                Strength = 4,
                Courage = 1,
                Skill = 2
            };
            var survivors = WarSimulationService.OneOnOneBattle(a, b);
            Assert.IsNotNull(survivors);
            Assert.IsTrue(survivors.Contains(b));
            Assert.IsTrue(survivors.Contains(a));
        }
    }
}