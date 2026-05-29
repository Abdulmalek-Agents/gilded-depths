using Fusion;
using GildedDepths.Core;
using UnityEngine;

namespace GildedDepths.Net
{
    /// <summary>
    /// Drives the ruin's collapse pressure over the network. Uses the pure <see cref="CollapseModel"/>
    /// for the math and replicates the resulting risk as a [Networked] value so every peer's
    /// HUD/audio/VFX agree and the forced-escape begins for everyone simultaneously.
    /// </summary>
    public sealed class CollapseController : NetworkBehaviour
    {
        [SerializeField] private float riskPerSecond = 0.0025f;
        [SerializeField] private float riskPerTrap = 0.1f;

        private CollapseModel _model;

        [Networked, OnChangedRender(nameof(OnRiskChanged))]
        public float Risk01 { get; private set; }
        [Networked] public NetworkBool ForcedEscape { get; private set; }

        public override void Spawned() => _model = new CollapseModel(riskPerSecond, riskPerTrap);

        public override void FixedUpdateNetwork()
        {
            if (!HasStateAuthority || _model == null) return;
            _model.Tick(Runner.DeltaTime);
            Risk01 = _model.Risk01;
            ForcedEscape = _model.ForcedEscape;
        }

        /// <summary>Call when a trap is tripped (state authority).</summary>
        public void OnTrapTriggered() { if (HasStateAuthority) _model?.TriggerTrap(); }

        private void OnRiskChanged()
        {
            // TODO(M4): drive dust/cracks VFX + intensifying ambience; begin escape sequence on ForcedEscape.
        }
    }
}
