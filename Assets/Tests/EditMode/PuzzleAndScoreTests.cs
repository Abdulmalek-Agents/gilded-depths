using System.Collections.Generic;
using GildedDepths.Core;
using NUnit.Framework;

namespace GildedDepths.Tests
{
    public class PuzzleAndScoreTests
    {
        [Test]
        public void HintTimer_SurfacesHintAfterIdleThreshold()
        {
            var t = new HintTimer(idleThresholdSeconds: 5f);
            t.Tick(4f);
            Assert.IsFalse(t.HintReady);
            t.Tick(2f);
            Assert.IsTrue(t.HintReady);
        }

        [Test]
        public void HintTimer_ActivityResetsHint()
        {
            var t = new HintTimer(5f);
            t.Tick(6f);
            Assert.IsTrue(t.HintReady);
            t.RegisterActivity();
            Assert.IsFalse(t.HintReady);
        }

        [Test]
        public void HintTimer_DisabledWhenThresholdNonPositive()
        {
            var t = new HintTimer(0f);
            t.Tick(1000f);
            Assert.IsFalse(t.HintReady);
            Assert.IsFalse(t.Enabled);
        }

        [Test]
        public void Score_ScalesWithConditionAndAddsLore()
        {
            Assert.AreEqual(500, ExpeditionScore.Compute(1000, 0.5f, 0));
            Assert.AreEqual(750, ExpeditionScore.Compute(1000, 0.5f, 250));
        }

        [Test]
        public void VariantSelector_PicksMostDemandingSatisfiableVariant()
        {
            // Crew has Lantern + Ledger (a 2-player duo).
            var available = ToolType.Lantern | ToolType.Ledger;
            var variants = new List<ToolType>
            {
                ToolType.Lantern,                                   // 0: easiest
                ToolType.Lantern | ToolType.Ledger,                 // 1: best fit
                ToolType.Lantern | ToolType.Ledger | ToolType.Grapple // 2: needs a tool we lack
            };
            Assert.AreEqual(1, PuzzleVariantSelector.SelectVariant(available, variants));
        }

        [Test]
        public void VariantSelector_ReturnsMinusOneWhenNothingSatisfiable()
        {
            var available = ToolType.Brush;
            var variants = new List<ToolType> { ToolType.Lantern, ToolType.Ledger };
            Assert.AreEqual(-1, PuzzleVariantSelector.SelectVariant(available, variants));
        }
    }
}
