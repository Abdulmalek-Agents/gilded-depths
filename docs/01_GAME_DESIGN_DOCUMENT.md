# Gilded Depths — Game Design Document (GDD)

**Version:** 1.0 (Phase 1)  ·  **Owner:** Game Design team  ·  **Engine:** Unity 6000.4.4f1 / URP  ·  **Net:** Photon Fusion 2 (Shared Mode)

---

## 1. Vision statement

Gilded Depths is the co-op puzzle game friends *evangelize*. It is impossible to solve alone: each explorer holds a different piece of the truth, and only by describing what you see, anchoring a rope for a teammate, or decoding a glyph someone else illuminated can the crew descend deeper and escape with the treasure. It aims squarely at the **99%-positive** band by being tight, fair, beautiful, and unforgettable to play *with someone*.

## 2. Design pillars

1. **No one can win alone.** Information and capability are split across roles. Communication *is* the gameplay.
2. **Fair, never opaque.** Every puzzle is solvable on the first earnest attempt with good communication. No moon-logic. Hints exist to prevent review-killing hard stops.
3. **Tension without cruelty.** Collapse timers and fragile artifacts create stakes; generous checkpoints keep failure from feeling punishing.
4. **Beauty as reward.** Each ruin is a hand-tuned, atmospheric set-piece that pays off the descent.
5. **Readable asymmetry.** Players instantly understand *what only they* can do — and therefore why they matter.

## 3. Target audience & market fit

- **Primary:** 2-player duos and 3–4 friend groups who loved We Were Here, Operation Tango, Escape Simulator, Portal 2 co-op.
- **Secondary:** couples/date-night co-op (a proven, high-retention niche) and puzzle streamers.
- **Fit:** premium $12.99–$16.99, gift-able, high review ceiling, strong word-of-mouth ("play this with me").

## 4. Core gameplay loop

```
DESCEND  →  SURVEY (split info)  →  SOLVE asymmetric puzzle  →  UNLOCK passage / lower collapse risk  →
HAUL artifact  →  TRAVERSE hazard  →  REACH vault  →  ESCAPE before collapse  →  CATALOG + lore  → (next ruin)
```

## 5. The asymmetric toolset (signature system)

Each player equips **one** primary tool at a ruin's start (a crew of 2 carries 2; a crew of 4 carries all 4). Puzzles are authored to require **≥ 2 distinct tools** in combination.

| Tool | Holder can… | Cannot (depends on others) |
|---|---|---|
| **Lantern** | Reveal hidden glyphs/ink, light dark rooms, expose pressure plates | Read meaning of glyphs (needs Ledger), reach high anchors (needs Grapple) |
| **Grapple** | Cross gaps, set anchors/zip-lines for others, pull levers at distance | See what's worth grappling to in the dark (needs Lantern) |
| **Brush** | Clean surfaces to expose clues, defuse dust/trap triggers, restore murals | Decode the cleaned symbols (needs Ledger) |
| **Ledger** | Decode glyphs, map the ruin, mark teammate-reported clues, track collapse risk | Physically reach/illuminate/clean the clues (needs the others) |

**Asymmetry rule:** the holder of a tool always has a *clear solo micro-loop* (something useful to do) plus a *forced collaboration* (the actual progress). This keeps all 2–4 players continuously engaged.

## 6. Puzzle design framework

- **Three tiers per ruin:** (a) *Survey* puzzles (gather/share info), (b) *Mechanism* puzzles (coordinate simultaneous actions), (c) *Gate* puzzle (the ruin's capstone requiring all available tools).
- **The "two-truths" template:** Player A sees a symbol but not its meaning; Player B (Ledger) sees the key but not the symbol. They must talk. This is the reusable backbone, varied with mechanics each ruin.
- **Anti-frustration:** an in-world **"echo ping"** lets any player mark a point of interest; after a tunable idle timer, a diegetic hint nudges without solving. Tracked by QA to keep first-attempt solve rates in the target band.

## 7. Hazards & the collapse system

- **Collapse meter** per ruin rises with time and with triggered traps; reaching thresholds closes routes and finally forces an escape sequence. It creates urgency without twitch reflexes.
- **Fragile artifacts** have a condition value; careless hauling (drops, hazard exposure) reduces final payout — echoing R.E.P.O.'s value tension but in a deliberate, non-physics-jank way.
- **Hazards:** crumbling floors (need Grapple), dark pits (need Lantern), trapped reliefs (need Brush), warded doors (need Ledger). Always a tool-keyed, communicable solution.

## 8. Content & depth to ~10 hours

| Source of depth | Detail | Est. hours |
|---|---|---|
| **6 ruins** | Sunken Atrium, Mirror Catacomb, Root Cathedral, Ashfall Forge, Tidal Archive, the Gilded Vault | ~6.5 |
| **Asymmetric re-roles** | Replays with different tool assignments change everyone's experience | +1.0 |
| **Deep-Vault hard variants** | Optional harder cut of each ruin (tighter timers, sparser hints) | +1.5 |
| **Lore tablets + NG+ "Blackout"** | Collectible narrative + a no-map modifier | +1.0 |
| **Total** | | **~10h** |

## 9. Progression

- **Cosmetic + lore progression**, not power. Players unlock tool skins, expedition journal entries, and ruin lore. No mechanical power creep — keeps puzzles balanced and pairs of any skill able to play together (protects review score).

## 10. Multiplayer design

- **Model:** **Photon Fusion 2 Shared Mode** — lightweight state replication ideal for low-bandwidth, deterministic puzzle interactions; built-in matchmaking/quick-join + friend invites.
- **Why Fusion 2 here (vs Mirror):** puzzle interactions are low-frequency, state-based events (levers, plates, decode states) — Fusion's state sync + managed cloud removes server/host-NAT pain and gives instant friend matchmaking with minimal engineering.
- **Player count scaling:** puzzles detect available tools (2–4 players) and present the matching variant so any crew size gets a complete, fair experience.
- **Voice:** integrated push-to-talk + positional voice; the entire design assumes players are talking.

## 11. Camera, controls, UX

- First-person (maximizes immersion + "what do you see?" asymmetry). Cinemachine for scripted reveal/escape beats.
- Input System; gamepad + KB/M. Context interact, tool-action button, echo-ping button, journal/map (Ledger sees richest version).
- HUD: minimal — tool prompt, collapse risk indicator (diegetic dust/cracks first, UI second), ping markers, voice indicators.

## 12. Audio & atmosphere

- Reactive ambience: dripping water, distant groans of stressed stone that intensify with collapse risk (diegetic tension telegraph).
- Triumphant reveal stingers on solves; awe cue on entering each vault.

## 13. Accessibility

- Colorblind-safe glyph differentiation (shape + color), full subtitles/captions, dyslexia-friendly font option for the Ledger, remappable controls, adjustable hint timing (including "off" for purists and "generous" for casual nights).

## 14. Monetization & pricing

- **Premium one-time $12.99–$16.99.** Optional cosmetic packs / future ruin-pack DLC. No microtransactions in puzzles.

## 15. MVP / vertical slice scope

Phase 2–3 vertical slice: **Ruin 1 (Sunken Atrium)**, all 4 tools, 1 survey + 1 mechanism + 1 gate puzzle, the collapse + escape sequence, 1 artifact haul, 2–4p networked play, voice, echo-ping/hint system. All other ruins reuse these systems.

## 16. Success metrics (target)

- **≥95% positive** Steam reviews (target 99% band); **≥90% first-attempt gate-solve** with communication; near-zero "we got hard-stuck" reviews.
- Strong **co-op-required** signal in reviews ("must play with a friend") to drive gift/word-of-mouth sales.

## 17. References / comps

We Were Here series, Operation Tango, Escape Simulator, Portal 2 co-op, Indiana Jones / Uncharted set-piece tone, R.E.P.O. (value-haul tension).
