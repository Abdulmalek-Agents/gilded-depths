# Gilded Depths — Technical Design Document (TDD)

**Version:** 1.0 (Phase 2)  ·  **Owner:** Lead Unity Architect + Networking Engineers  ·  **Engine:** Unity 6000.4.4f1 / URP

---

## 1. High-level architecture

```
Assets/_Project/Scripts/
  Core/        → expedition flow, collapse model, hint timer, scoring, interfaces (NO Fusion deps)
  Net/         → Photon Fusion 2 runner, session launcher, networked explorer/tool/puzzle/artifact
  Puzzle/      → puzzle node behaviours, asymmetric checks
  Player/      → first-person controller, tool use, interaction
  Environment/ → ruin streaming, hazards, collapse VFX
  UI/          → HUD, journal/map (Ledger), ping wheel
  Audio/       → reactive ambience driver
```

Assemblies: `GildedDepths.Runtime` (pure logic, no Fusion), `GildedDepths.Net` (Fusion), `GildedDepths.Tests.EditMode`. Dependencies point inward.

## 2. Networking model

- **Stack:** **Photon Fusion 2 — Shared Mode** + Photon Cloud (matchmaking, relay).
- **Why Fusion 2 Shared Mode:** puzzle interactions are **low-frequency, state-based events** (a lever flips, a plate is pressed, a glyph is decoded). Shared Mode gives each client authority over its own objects with cheap `[Networked]` state replication, while Photon Cloud removes host/NAT/dedicated-server pain and provides **instant friend matchmaking** with minimal engineering — the lowest-effort path for this genre.
- **State sync:** puzzle/lever/plate/door states and artifact condition are `[Networked]` properties with `OnChanged` render callbacks. Interactions route through `RPC`s or state-authority changes.
- **Player-count scaling:** the `ToolHolder` reports which of the 4 tools are present; `PuzzleNode` selects the variant matching the available toolset (2–4 players) so every crew size gets a complete, fair puzzle.
- **Voice:** Photon Voice (integrates with Fusion) for push-to-talk + positional audio. The design assumes constant communication.
- **App ID:** stored in `PhotonAppSettings` — **never committed** (gitignored).

## 3. Why not Mirror here?

Mirror is excellent and remains our fallback, but it needs us to solve matchmaking/NAT/hosting ourselves. For a low-bandwidth, friends-quick-join puzzle game, Fusion 2's managed cloud + Shared Mode minimizes engineering time and maximizes "click invite, instantly playing" — directly serving the review-score and word-of-mouth goals.

## 4. Core systems (see code stubs)

- `ExpeditionStateMachine` — Boot → Menu → Lobby → Circle(hub) → Descend → Escape → Catalog.
- `CollapseModel` — pure logic: accumulates collapse risk from time + trap triggers, exposes thresholds & the forced-escape flag. Unit-tested.
- `HintTimer` — pure logic: tracks idle time on a puzzle and decides when to surface a diegetic hint (anti-frustration). Unit-tested.
- `ExpeditionScore` — pure logic: artifact value × condition + lore bonus. Unit-tested.
- Interfaces: `ITool`, `IToolUser`, `IPuzzleNode`, `IInteractable`, `IArtifact`, `ICollapseListener`.

## 5. Puzzle authority & determinism

- Puzzle outcomes are **state-based, not physics-based**, so they are deterministic and trivially synced. A node holds `[Networked]` solved-state; clients render to match. No floating-point race conditions.

## 6. Data & save

- Local profile: unlocked tool skins, journal/lore entries, settings, hint-timing preference. Per-ruin best times. No accounts at launch.

## 7. Performance budget

| Target | Spec |
|---|---|
| 1080p 60 FPS | mid PC (GTX 1660 class) |
| Steam Deck | 60 FPS (low-physics game; lighting is the cost) |
| Frame budget | ≤ 16.6 ms; render ≤ 10 ms (baked GI heavy) |
| Draw calls | < 1200 (SRP Batcher, modular kit instancing) |

Lighting (atmosphere) is the dominant cost: bake static GI per ruin, use light probes for the moving Lantern light, cap real-time lights, additive scene streaming per section.

## 8. Risk register (technical)

| Risk | Mitigation |
|---|---|
| Puzzle desync edge cases | State-based `[Networked]` props + OnChanged; authority transfer tested |
| Player gets hard-stuck (review killer) | `HintTimer` + echo-ping; QA tracks first-attempt solve rate |
| Baked-lighting build times/size | Per-ruin lightmap budgets; streamed sections |
| Photon CCU costs at scale | Shared Mode is cheap per-CCU; monitor; Mirror fallback documented |
