using Fusion;
using GildedDepths.Core;
using UnityEngine;

namespace GildedDepths.Net
{
    /// <summary>
    /// Holds the explorer's single asymmetric tool. The assignment is networked so every peer
    /// knows who can do what — the basis of the "no one can win alone" design.
    /// </summary>
    public sealed class ToolHolder : NetworkBehaviour, IToolUser
    {
        [Networked] public ToolType CarriedTool { get; private set; }

        /// <summary>Assign at ruin start (state authority). 2-player crews carry 2 tools, etc.</summary>
        public void Assign(ToolType tool)
        {
            if (HasStateAuthority) CarriedTool = tool;
        }

        /// <summary>Aggregate the tools present in the crew (used by PuzzleVariantSelector).</summary>
        public static ToolType AggregateAvailable(ToolHolder[] crew)
        {
            var available = ToolType.None;
            foreach (var member in crew) available |= member.CarriedTool;
            return available;
        }
    }
}
