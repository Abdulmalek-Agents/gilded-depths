using System;

namespace GildedDepths.Core
{
    /// <summary>Pure payout math for an expedition. Identical on every client.</summary>
    public static class ExpeditionScore
    {
        /// <summary>
        /// Payout = round(artifactBaseValue * condition) + loreBonus, clamped to >= 0.
        /// Progression is cosmetic/lore only — there is no power score (protects puzzle balance).
        /// </summary>
        public static int Compute(int artifactBaseValue, float condition01, int loreBonus)
        {
            var condition = Math.Clamp(condition01, 0f, 1f);
            var raw = (int)Math.Round(artifactBaseValue * condition) + Math.Max(0, loreBonus);
            return Math.Max(0, raw);
        }
    }
}
