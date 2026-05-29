using System.Collections.Generic;

namespace GildedDepths.Core
{
    /// <summary>
    /// Chooses which puzzle variant to present based on the tools the present crew is
    /// carrying (2–4 players). Picks the most demanding variant that is fully satisfiable
    /// by the available toolset, so every crew size gets a complete, fair puzzle.
    /// Pure & static → unit-tested.
    /// </summary>
    public static class PuzzleVariantSelector
    {
        /// <summary>
        /// Returns the index of the best variant whose required tools are a subset of
        /// <paramref name="available"/> (preferring the one that uses the most tools),
        /// or -1 if none are satisfiable.
        /// </summary>
        public static int SelectVariant(ToolType available, IReadOnlyList<ToolType> variantRequirements)
        {
            var best = -1;
            var bestToolCount = -1;
            for (var i = 0; i < variantRequirements.Count; i++)
            {
                var req = variantRequirements[i];
                if ((req & ~available) != ToolType.None) continue; // needs a tool we don't have
                var count = CountTools(req);
                if (count > bestToolCount) { bestToolCount = count; best = i; }
            }
            return best;
        }

        private static int CountTools(ToolType mask)
        {
            var n = 0;
            var v = (int)mask;
            while (v != 0) { v &= v - 1; n++; }
            return n;
        }
    }
}
