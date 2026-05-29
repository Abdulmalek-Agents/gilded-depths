using System;
using UnityEngine;

namespace GildedDepths.Core
{
    /// <summary>The four asymmetric tools. [Flags] so puzzles can require combinations.</summary>
    [Flags]
    public enum ToolType
    {
        None    = 0,
        Lantern = 1 << 0, // reveal glyphs / light
        Grapple = 1 << 1, // traversal / anchors
        Brush   = 1 << 2, // clean clues / defuse dust traps
        Ledger  = 1 << 3  // decode glyphs / map
    }

    /// <summary>A tool carried by an explorer.</summary>
    public interface ITool { ToolType Type { get; } void Use(GameObject user); }

    /// <summary>An explorer who carries exactly one primary tool.</summary>
    public interface IToolUser { ToolType CarriedTool { get; } }

    /// <summary>Anything the crew can interact with.</summary>
    public interface IInteractable { string Prompt { get; } void Interact(GameObject who); }

    /// <summary>A puzzle element with a networked solved-state.</summary>
    public interface IPuzzleNode
    {
        bool IsSolved { get; }
        /// <summary>Tools required to solve this node (a [Flags] mask of ToolType).</summary>
        ToolType RequiredTools { get; }
    }

    /// <summary>A fragile artifact whose surviving condition drives payout.</summary>
    public interface IArtifact { float Condition01 { get; } void ApplyDamage(float amount); }

    /// <summary>Receives collapse-risk updates (HUD/audio/VFX).</summary>
    public interface ICollapseListener { void OnCollapseRiskChanged(float risk01, bool forcedEscape); }
}
