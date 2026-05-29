using GildedDepths.Core;
using NUnit.Framework;

namespace GildedDepths.Tests
{
    public class CollapseModelTests
    {
        [Test]
        public void Tick_AccumulatesRiskOverTime()
        {
            var m = new CollapseModel(riskPerSecond: 0.1f, riskPerTrap: 0.1f, forcedEscapeThreshold: 1f);
            m.Tick(2f);
            Assert.AreEqual(0.2f, m.Risk01, 1e-4);
        }

        [Test]
        public void TriggerTrap_RaisesRiskInSteps()
        {
            var m = new CollapseModel(0.0f, 0.25f);
            m.TriggerTrap();
            m.TriggerTrap(2);
            Assert.AreEqual(0.75f, m.Risk01, 1e-4);
        }

        [Test]
        public void Risk_IsClampedToOne_AndForcedEscapeFires()
        {
            var m = new CollapseModel(0f, 1f, forcedEscapeThreshold: 1f);
            m.TriggerTrap(5);
            Assert.AreEqual(1f, m.Risk01, 1e-4);
            Assert.IsTrue(m.ForcedEscape);
        }

        [Test]
        public void Relieve_LowersRisk()
        {
            var m = new CollapseModel(0f, 0.5f);
            m.TriggerTrap();        // 0.5
            m.Relieve(0.3f);        // 0.2
            Assert.AreEqual(0.2f, m.Risk01, 1e-4);
            Assert.IsFalse(m.ForcedEscape);
        }
    }
}
