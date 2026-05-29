using Fusion;
using GildedDepths.Core;
using UnityEngine;

namespace GildedDepths.Net
{
    /// <summary>
    /// A fragile artifact to haul out. Condition is networked so HUD and final payout agree
    /// across all clients. Careless hauling (drops/hazards) lowers the surviving payout.
    /// </summary>
    public sealed class Artifact : NetworkBehaviour, IArtifact
    {
        [Networked] public float Condition01 { get; private set; } = 1f;

        public override void Spawned() { if (HasStateAuthority) Condition01 = 1f; }

        public void ApplyDamage(float amount)
        {
            if (!HasStateAuthority) return;
            Condition01 = Mathf.Clamp01(Condition01 - Mathf.Max(0f, amount));
        }
    }
}
