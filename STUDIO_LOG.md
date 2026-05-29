# STUDIO_LOG — Gilded Depths

Living log of phases, decisions, blockers, retries, asset-placement notes, and next steps. Newest entries on top.

---

## Phase 2 — Technical & Assets  ·  status: IN REVIEW → PR open

### Done
- `docs/02_TECHNICAL_DESIGN_DOCUMENT.md` — architecture, **Photon Fusion 2 Shared-Mode** model + rationale (vs Mirror), state-based puzzle determinism, perf budget (lighting-led), risk register.
- `docs/03_IMPLEMENTATION_GUIDELINES.md` — M0–M6 build plan, coding standards, DoD, paired-playtest test strategy.
- `docs/04_UNITY_ASSET_INTEGRATION.md` — evaluated asset list (Fusion 2, Photon Voice, modular ruins kit, atmosphere/fog, stylized water, DOTween Pro, FMOD, Easy Save 3) with license/perf/conflict notes + integration rules (no committed App IDs).
- `docs/05_ART_AND_ENVIRONMENT_PLAN.md` — lighting-led art direction, ruin palettes, **environment dressing standards** (grounding/pivots/lightmap-UVs/no-light-leaks/hierarchy), bake plan, optimization.
- `docs/06_QA_TEST_PLAN.md` — QA mandate incl. **puzzle solvability metrics** (≥ 90% first-attempt solve), test matrix, environment-review checklist, gates.
- **Code stubs** (SOLID, fully commented): Core (Fusion-free) `Interfaces` (ToolType flags), `CollapseModel`, `HintTimer`, `ExpeditionScore`, `PuzzleVariantSelector`; Net (Fusion 2) `SessionLauncher`, `ToolHolder`, `PuzzleNode`, `Artifact`, `CollapseController`. Assemblies isolate Core from Fusion.
- **Unit tests:** `CollapseModelTests`, `PuzzleAndScoreTests` (collapse math, hint timer, scoring, asymmetric variant selection).

### Decisions
- Core assembly (`GildedDepths.Runtime`) is **forbidden from referencing Fusion**; networked code lives in `GildedDepths.Net`.
- Puzzles are **state-based, not physics-based** → deterministic, trivially synced, no desync.
- **Toolset-variant selection** lets any crew size (2–4) get a complete, fair puzzle.
- Photon App ID **never committed** (gitignored); secret-scan on each phase.

### Asset-placement notes
- No scenes dressed yet (skeleton). First environment-review pass occurs in Phase 3 (Sunken Atrium). Ruins-kit props flagged for pivot/grounding + **lightmap-UV / light-leak** audit on import (lighting is the art here).

### Retry log
- No retryable tool errors encountered this phase.

### Next steps (Phase 3)
- Build the Sunken Atrium vertical slice; full descend→solve→haul→escape 2–4p; Photon Voice; CI (lint + EditMode tests); joint QA + Art/Environment review; ≥ 90% first-attempt solve gate.

---

## Phase 1 — Foundation  ·  status: MERGED ✅

### Done
- Repo created in `Abdulmalek-Agents` org; `phase-1-foundation` branch; PR #1 merged after QA sign-off.
- Unity **6000.4.4f1** skeleton (URP 17, Cinemachine 3, Input System, Test Framework), `.gitignore`, `Assets/_Project` structure.
- Design docs: GDD (`01`), Narrative bible (`07` — the Gildfolk, six ruins), Portfolio validation (`00`), this log.

### Decisions
- **Networking = Photon Fusion 2 (Shared Mode) + Photon Cloud matchmaking.** Mirror = documented fallback.
- **URP** (approved exception to studio HDRP default).
- **Cosmetic/lore-only progression** + **echo-ping/timed-hint** anti-frustration system to protect the 99% review target.

### Retry log
- None.
