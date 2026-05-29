using System;

namespace GildedDepths.Core
{
    /// <summary>
    /// Anti-frustration timer. Tracks idle time since the crew last made progress on a puzzle;
    /// when idle exceeds the threshold it flags that a diegetic hint should surface. This is
    /// the system that protects the 99% review target from review-killing hard-stops.
    /// Pure logic → unit-tested. The threshold is player-adjustable (off → generous).
    /// </summary>
    public sealed class HintTimer
    {
        private readonly float _idleThresholdSeconds;
        private float _idle;

        /// <summary>True once idle time has exceeded the threshold (and a hint is due).</summary>
        public bool HintReady { get; private set; }

        /// <param name="idleThresholdSeconds">Use 0 or negative to disable hints entirely.</param>
        public HintTimer(float idleThresholdSeconds = 90f) => _idleThresholdSeconds = idleThresholdSeconds;

        public bool Enabled => _idleThresholdSeconds > 0f;

        /// <summary>Call whenever the crew makes meaningful progress / interacts.</summary>
        public void RegisterActivity() { _idle = 0f; HintReady = false; }

        /// <summary>Advance time. Sets <see cref="HintReady"/> when idle exceeds threshold.</summary>
        public void Tick(float deltaSeconds)
        {
            if (!Enabled) return;
            _idle += Math.Max(0f, deltaSeconds);
            if (_idle >= _idleThresholdSeconds) HintReady = true;
        }
    }
}
