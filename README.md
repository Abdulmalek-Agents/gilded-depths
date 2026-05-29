# Gilded Depths

> **Two lanterns, one collapsing tomb, no way out but together.**

A **2–4 player co-op asymmetric puzzle-traversal archaeology** game for PC (Steam).
Lineage: *We Were Here* × *Indiana Jones* × *R.E.P.O.*'s value-hauling tension.

| | |
|---|---|
| **Engine** | Unity **6000.4.4f1** |
| **Render Pipeline** | URP (Universal Render Pipeline) |
| **Networking** | **Photon Fusion 2** (Shared Mode) + Photon Cloud matchmaking |
| **Players** | 2–4 co-op |
| **Target playtime** | ~10 hours (6 collapsing ruins + deep-vault variants + lore) |
| **Platform** | Windows 64-bit (Steam), Steam Deck verified target |
| **Price point** | $12.99–$16.99 (premium puzzle, gift-able) |

---

## The pitch

A team of "tomb cartographers" descends into procedurally-assembled ancient ruins. Each explorer carries a **different asymmetric tool** — **Lantern**, **Grapple**, **Brush**, **Ledger** — so *no puzzle is solvable alone*. Solve environmental puzzles, haul fragile artifacts toward the surface, and escape before timed structural collapses bury you. The game is engineered to be the one your friends *insist* you play with them.

## Why this game (validated)

We Were Here-style co-op-required puzzlers consistently review extremely well and spread by word of mouth ("you HAVE to play this with me"). It has the highest *review-score ceiling* of our slate and the lowest technical risk — no complex AI or physics-jank. Full evidence: [`docs/00_PORTFOLIO_5_IDEAS_AND_VALIDATION.md`](docs/00_PORTFOLIO_5_IDEAS_AND_VALIDATION.md).

## Documentation

| Doc | Purpose |
|---|---|
| [`docs/00_PORTFOLIO_5_IDEAS_AND_VALIDATION.md`](docs/00_PORTFOLIO_5_IDEAS_AND_VALIDATION.md) | The 5-concept slate + market validation |
| [`docs/01_GAME_DESIGN_DOCUMENT.md`](docs/01_GAME_DESIGN_DOCUMENT.md) | Full GDD |
| [`docs/02_TECHNICAL_DESIGN_DOCUMENT.md`](docs/02_TECHNICAL_DESIGN_DOCUMENT.md) | Architecture & networking (Phase 2) |
| [`docs/03_IMPLEMENTATION_GUIDELINES.md`](docs/03_IMPLEMENTATION_GUIDELINES.md) | Phase-by-phase build plan (Phase 2) |
| [`docs/04_UNITY_ASSET_INTEGRATION.md`](docs/04_UNITY_ASSET_INTEGRATION.md) | Asset Store integration plan (Phase 2) |
| [`docs/05_ART_AND_ENVIRONMENT_PLAN.md`](docs/05_ART_AND_ENVIRONMENT_PLAN.md) | Art direction & environment standards (Phase 2) |
| [`docs/06_QA_TEST_PLAN.md`](docs/06_QA_TEST_PLAN.md) | QA & environment-review gates (Phase 2) |
| [`docs/07_NARRATIVE_AND_WORLD.md`](docs/07_NARRATIVE_AND_WORLD.md) | World, tone & writing bible |
| [`STUDIO_LOG.md`](STUDIO_LOG.md) | Living phase/decision log |

## Branch & phase workflow

QA-gated phases on feature branches → PR → merge after QA + Art/Environment sign-off.

- `phase-1-foundation` — skeleton + design/narrative docs
- `phase-2-tech-and-assets` — technical design, implementation guide, asset plan, code stubs, tests

---
_© Abdulmalek-Agents. Internal concept project._
