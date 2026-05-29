# STUDIO_LOG — Gilded Depths

Living log of phases, decisions, blockers, retries, asset-placement notes, and next steps. Newest entries on top.

---

## Phase 1 — Foundation  ·  status: IN REVIEW → PR open

**Date:** project kickoff.

### Done
- Repo created in `Abdulmalek-Agents` org.
- Branch `phase-1-foundation` created.
- Unity **6000.4.4f1** project skeleton committed: `ProjectSettings/ProjectVersion.txt`, `Packages/manifest.json` (URP 17, Cinemachine 3, Input System, Test Framework), Unity `.gitignore`, `Assets/_Project` folder structure.
- Design docs committed: GDD (`01`), Narrative & World bible (`07`), Portfolio validation (`00`), this log.

### Decisions
- **Networking = Photon Fusion 2 (Shared Mode) + Photon Cloud matchmaking.** Rationale: puzzle interactions are low-frequency state events; Fusion's managed cloud removes host/NAT pain and gives instant friend matchmaking with minimal engineering. Mirror documented as fallback for self-hosting.
- **Render pipeline = URP** (stylized-realistic ruins, Steam-Deck-friendly) — approved exception to studio HDRP default for perf + scope.
- **Progression = cosmetic/lore only, no power creep** — protects puzzle balance and cross-skill co-op (review-score safeguard).
- **Anti-frustration "echo-ping + timed hint" system mandated** to prevent review-killing hard stops.

### Blockers resolved
- None.

### Retry log
- No retryable tool errors encountered this phase.

### Next steps (Phase 2)
- Technical Design Doc, Implementation Guidelines, Unity Asset Integration plan, Art & Environment plan, QA Test Plan.
- C# core stubs (SOLID, fully commented) + unit-test stubs.
- Open Phase 1 PR; merge after QA + Art/Environment sign-off.
