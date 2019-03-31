using MultiWorld.Models;
using MultiWorld.Services;
using NUnit.Framework;
using System;

namespace MultiWorld.Tests.UnitTests
{
    public class BattleSkillRuleTests
    {
        [Test]
        public void Skill_6vs1_A_Wins()
        {
            var a = new Transformer()
            {
                Id = Guid.NewGuid(),
                Skill = 6
            };
            var b = new Transformer()
            {
                Id = Guid.NewGuid(),
                Skill = 1
            };
            var survivor = BattleRules.SkillRule(a, b);
            Assert.IsNotNull(survivor);
            Assert.AreEqual(a.Id, survivor.Id);
            Assert.AreNotEqual(b.Id, survivor.Id);
        }
        [Test]
        public void Skill_5vs1_NoOne_Wins()
        {
            var a = new Transformer()
            {
                Id = Guid.NewGuid(),
                Skill = 5
            };
            var b = new Transformer()
            {
                Id = Guid.NewGuid(),
                Skill = 1
            };
            var survivor = BattleRules.SkillRule(a, b);
            Assert.IsNull(survivor);
        }
        [Test]
        public void Skill_1vs6_B_Wins()
        {
            var a = new Transformer()
            {
                Id = Guid.NewGuid(),
                Skill = 1
            };
            var b = new Transformer()
            {
                Id = Guid.NewGuid(),
                Skill = 6
            };
            var survivor = BattleRules.SkillRule(a, b);
            Assert.IsNotNull(survivor);
            Assert.AreEqual(b.Id, survivor.Id);
            Assert.AreNotEqual(a.Id, survivor.Id);
        }
        [Test]
        public void Skill_1vs5_NoOne_Wins()
        {
            var a = new Transformer()
            {
                Id = Guid.NewGuid(),
                Skill = 1
            };
            var b = new Transformer()
            {
                Id = Guid.NewGuid(),
                Skill = 5
            };
            var survivor = BattleRules.SkillRule(a, b);
            Assert.IsNull(survivor);
        }
    }
}