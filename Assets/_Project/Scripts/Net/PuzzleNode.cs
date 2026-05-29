using Fusion;
using GildedDepths.Core;
using UnityEngine;

namespace GildedDepths.Net
{
    /// <summary>
    /// A networked puzzle element. Solved-state is a [Networked] bool replicated to all peers
    /// via a render-change callback — deterministic, low-bandwidth, no physics race conditions.
    /// Requires a tool mask to solve (asymmetry enforced).
    /// </summary>
    public sealed class PuzzleNode : NetworkBehaviour, IPuzzleNode
    {
        [SerializeField] private ToolType requiredTools = ToolType.Lantern | ToolType.Ledger;

        [Networked, OnChangedRender(nameof(OnSolvedChanged))]
        public bool IsSolved { get; private set; }

        public ToolType RequiredTools => requiredTools;

        /// <summary>Attempt to solve using the tools currently available to the crew.</summary>
        public void TrySolve(ToolType availableTools)
        {
            if (IsSolved) return;
            if ((requiredTools & ~availableTools) != ToolType.None) return; // missing a required tool
            if (HasStateAuthority) IsSolved = true;
        }

        private void OnSolvedChanged()
        {
            // TODO(M3): play reveal VFX/SFX, open the gate, relieve some collapse risk.
            Debug.Log($"[Puzzle] Node solved (required {requiredTools}).");
        }
    }
}
