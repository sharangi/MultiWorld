using MultiWorld.Models;
using MultiWorld.Services;
using NUnit.Framework;
using System;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace MultiWorld.Tests.UnitTests
{
    public class WarSimulationServiceTests
    {
        List<Transformer> _autobots;
        List<Transformer> _decepticons;
        WarSimulationService _warSimulationService;
        [SetUp]
        public void Setup()
        {
            _autobots = new List<Transformer>();
            _decepticons = new List<Transformer>();

            var mockTransformerService = new Mock<ITransformerService>();
            mockTransformerService.Setup(x => x.GetAllAutobots()).Returns(_autobots);
            mockTransformerService.Setup(x => x.GetAllDecepticons()).Returns(_decepticons);
            _warSimulationService = new WarSimulationService(mockTransformerService.Object);
        }
        [Test]
        public void NoSurvivors_Optimus_Predaking()
        {
            _autobots.Clear();
            _decepticons.Clear();

            _autobots.Add(new Transformer() { Name = BattleRules.Optimus });
            _decepticons.Add(new Transformer() { Name = BattleRules.Predaking });

            var survivors = _warSimulationService.SimulateWar();
            Assert.IsNotNull(survivors);
            Assert.AreEqual(0,survivors.Count());
        }
        [Test]
        public void Survivor_Optimus_vs_NonPredaking_Optimus_Wins()
        {
            _autobots.Clear();
            _decepticons.Clear();

            var optimus = new Transformer()
            {
                Name = BattleRules.Optimus
            };
            var nonPredaking = new Transformer()
            {
                Name = "NonPredaking"
            };
            _autobots.Add(optimus);
            _decepticons.Add(nonPredaking);

            var survivors = _warSimulationService.SimulateWar();
            Assert.IsNotNull(survivors);
            Assert.IsTrue(survivors.Contains(optimus));
            Assert.IsFalse(survivors.Contains(nonPredaking));
        }
        [Test]
        public void RankingPairs_Works()
        {
            _autobots.Clear();
            _decepticons.Clear();

            var optimus = new Transformer()
            {
                Name = BattleRules.Optimus,
                Rank = 10
            };
            var bumbleBee = new Transformer()
            {
                Name = "BumbleBee",
                Rank = 5
            };
            var nonPredaking = new Transformer()
            {
                Name = "NonPredaking",
                Rank = 9
            };
            var deceptimus = new Transformer()
            {
                Name = BattleRules.Optimus,
                Rank = 7
            };
            _autobots.Add(optimus);
            _autobots.Add(bumbleBee);
            _decepticons.Add(nonPredaking);
            _decepticons.Add(deceptimus);

            var survivors = _warSimulationService.SimulateWar();
            Assert.IsNotNull(survivors);
            Assert.IsTrue(survivors.Contains(optimus));
            Assert.IsTrue(survivors.Contains(deceptimus));
            Assert.IsFalse(survivors.Contains(nonPredaking));
            Assert.IsFalse(survivors.Contains(bumbleBee));
        }
        [Test]
        public void Handling_Unpared_Autobots_Works()
        {
            _autobots.Clear();
            _decepticons.Clear();

            var optimus = new Transformer()
            {
                Name = BattleRules.Optimus,
                Rank = 10
            };
            var bumbleBee = new Transformer()
            {
                Name = "BumbleBee",
                Rank = 5
            };
            var nonPredaking = new Transformer()
            {
                Name = "NonPredaking",
                Rank = 9
            };
            _autobots.Add(optimus);
            _autobots.Add(bumbleBee);
            _decepticons.Add(nonPredaking);

            var survivors = _warSimulationService.SimulateWar();
            Assert.IsNotNull(survivors);
            Assert.IsTrue(survivors.Contains(optimus));
            Assert.IsTrue(survivors.Contains(bumbleBee));
            Assert.IsFalse(survivors.Contains(nonPredaking));
        }
        [Test]
        public void Handling_Unpared_Decepticons_Works()
        {
            _autobots.Clear();
            _decepticons.Clear();

            var optimus = new Transformer()
            {
                Name = BattleRules.Optimus,
                Rank = 10
            };
            var nonPredaking = new Transformer()
            {
                Name = "NonPredaking",
                Rank = 9
            };
            var deceptimus = new Transformer()
            {
                Name = BattleRules.Optimus,
                Rank = 7
            };
            _autobots.Add(optimus);
            _decepticons.Add(nonPredaking);
            _decepticons.Add(deceptimus);

            var survivors = _warSimulationService.SimulateWar();
            Assert.IsNotNull(survivors);
            Assert.IsTrue(survivors.Contains(optimus));
            Assert.IsTrue(survivors.Contains(deceptimus));
            Assert.IsFalse(survivors.Contains(nonPredaking));
        }
        [Test]
        public void WinWin_Works()
        {
            _autobots.Clear();
            _decepticons.Clear();

            var optimus = new Transformer()
            {
                Name = BattleRules.Optimus,
                Rank = 10
            };
            var deceptimus = new Transformer()
            {
                Name = BattleRules.Optimus,
                Rank = 7
            };
            _autobots.Add(optimus);
            _decepticons.Add(deceptimus);

            var survivors = _warSimulationService.SimulateWar();
            Assert.IsNotNull(survivors);
            Assert.IsTrue(survivors.Contains(optimus));
            Assert.IsTrue(survivors.Contains(deceptimus));
        }
    }
}
