using System;

namespace GildedDepths.Core
{
    /// <summary>
    /// Pure logic for a ruin's structural-collapse pressure. Risk rises with time and with
    /// triggered traps; crossing the forced-escape threshold begins the escape sequence.
    /// Engine-agnostic so it is fully unit-testable and deterministic across clients.
    /// </summary>
    public sealed class CollapseModel
    {
        private readonly float _riskPerSecond;
        private readonly float _riskPerTrap;

        /// <summary>Current accumulated risk, 0..1.</summary>
        public float Risk01 { get; private set; }
        public float ForcedEscapeThreshold { get; }
        public bool ForcedEscape => Risk01 >= ForcedEscapeThreshold;

        public CollapseModel(float riskPerSecond = 0.0025f, float riskPerTrap = 0.1f, float forcedEscapeThreshold = 1f)
        {
            _riskPerSecond = Math.Max(0f, riskPerSecond);
            _riskPerTrap = Math.Max(0f, riskPerTrap);
            ForcedEscapeThreshold = Math.Clamp(forcedEscapeThreshold, 0.01f, 1f);
        }

        /// <summary>Advance time (host authority calls this each network tick).</summary>
        public void Tick(float deltaSeconds) => Add(_riskPerSecond * Math.Max(0f, deltaSeconds));

        /// <summary>A trap was tripped (raises risk in a discrete step).</summary>
        public void TriggerTrap(int count = 1) => Add(_riskPerTrap * Math.Max(0, count));

        /// <summary>Solving a stabilizing mechanism can buy the crew time.</summary>
        public void Relieve(float amount) => Add(-Math.Max(0f, amount));

        private void Add(float delta) => Risk01 = Math.Clamp(Risk01 + delta, 0f, 1f);
    }
}
