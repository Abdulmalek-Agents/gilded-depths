# Gilded Depths — Implementation Guidelines (Build Plan)

**Version:** 1.0 (Phase 2)  ·  **Owner:** Lead Unity Architect + Senior Unity Developers

> Milestone-ordered, dependency-aware. No time estimates by policy.

## Coding standards
Same studio standard as the slate: C# 9+, one class/file, interfaces over transports, XML docs on public APIs, tunables in ScriptableObjects, EditMode test per logic system. `GildedDepths.Runtime` must NOT reference Fusion.

## Milestone sequence

### M0 — Project & pipeline
URP (lighting-quality tiers), Input System, assembly defs, folder structure, save service, first-person controller.
**DoD:** a single player walks through a greybox room and uses a test interactable.

### M1 — Networking spine (Fusion 2 Shared Mode)
Import Fusion 2; `DepthsRunnerHandler`, `SessionLauncher` (create/join/quick-join + friend invite), explorer spawn, Photon Voice.
**DoD:** 2–4 players join a session and see/hear each other in a greybox room.

### M2 — Asymmetric tools
`ToolHolder` + the 4 `ITool` implementations (Lantern, Grapple, Brush, Ledger), each with a clear solo micro-loop + a networked effect others can perceive.
**DoD:** each tool's effect is visible/usable by the whole crew over the network.

### M3 — Puzzle framework
`PuzzleNode` base, the "two-truths" template, a survey puzzle + a mechanism puzzle requiring ≥ 2 tools; variant selection by available toolset (2–4p).
**DoD:** a 2-player pair solves an asymmetric puzzle that neither could solve alone.

### M4 — Collapse, artifacts & escape
`CollapseController` (networked timer fed by `CollapseModel`), `Artifact` haul + condition, forced-escape sequence, `HintTimer` + echo-ping.
**DoD:** full descend→solve→haul→escape loop with stakes and no hard-stops.

### M5 — Vertical slice ruin (Sunken Atrium) + UX/Audio
Ruin 1 dressed + lit to ship quality, journal/map UI (Ledger), reactive ambience, accessibility, hint-timing options.
**DoD:** Sunken Atrium is demo-ready and passes the joint QA + Art/Environment review.

### M6 — Content scale-out
Remaining 5 ruins, Deep-Vault hard variants, lore tablets + NG+ Blackout, cosmetics, localization hooks.
**DoD:** ~10h target met; review-readiness checklist green.

## Definition of Done
Same as studio standard: reviewed + commented; test stub passing; networked path verified 2–4p; profiled; QA (+ Art/Environment for scenes) sign-off; STUDIO_LOG updated.

## Test strategy
- **EditMode:** collapse-risk math, hint-timer logic, scoring, toolset-variant selection.
- **PlayMode:** networked puzzle solve, artifact condition, escape trigger.
- **Network:** Fusion multi-peer + ParrelSync for 2–4 local peers; simulate latency.
- **Playtests:** mandatory paired (2p) and full (4p) playtests every milestone; record first-attempt solve rates.
