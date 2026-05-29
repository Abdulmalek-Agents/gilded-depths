# Gilded Depths — QA & Environment-Review Test Plan

**Version:** 1.0 (Phase 2)  ·  **Owner:** Senior QA Testers (with Technical Artist + 3D Modelers)

## 1. QA mandate (elevated)
QA actively **plays every scene in-editor** reading frame data / Profiler / console; reproduces every user-reported issue to root cause; assesses **asset placement** (position/rotation/scale, grounding, occlusion, hierarchy) to a senior environment-artist standard; validates feel, collision, LOD transitions, shadow casting, AO; and — uniquely for this game — **measures puzzle solvability** (first-attempt solve rate, time-to-solve, hard-stuck incidents) to defend the 99% review target. Structured bug reports tracked to closure.

## 2. Test matrix
| Area | Cases |
|---|---|
| **Networking** | 2/3/4-player quick-join + friend invite; mid-session join; peer drop; state-authority transfer; latency 150/300ms; reconnect |
| **Asymmetric tools** | Each tool usable & perceivable by all peers; toolset-variant selection correct for 2/3/4 players |
| **Puzzles** | Every gate solvable with communication on first earnest attempt; no moon-logic; **≥ 90% first-attempt solve** in playtests; hint timer surfaces correctly; echo-ping syncs |
| **Collapse/escape** | Risk accrual correct; thresholds close routes; forced-escape triggers; no unfair instant-loss |
| **Artifacts** | Condition decreases on mishandling; payout matches surviving condition across clients |
| **Perf** | 1080p60 mid-PC; Deck 60; draw calls < 1200; no light leaks; no GC spikes |
| **UX/Accessibility** | Rebinding; colorblind glyphs (shape+color); captions; dyslexia font; hint-timing slider (off→generous) |
| **Environment review** | Section 3 checklist on every scene |

## 3. Environment-review checklist (joint QA + Art)
Grounding (no float/clip), pivots correct, placement intentional & leads navigation, materials assigned (no magenta), **clean lightmap UVs / no light leaks**, smooth LODs, accurate collision, occlusion baked, AO present, hierarchy organized, prefabs for repeats, static flags correct.

## 4. Bug report template
```
ID:            GLD-###
Title:         <concise>
Severity:      Blocker / Critical / Major / Minor / Polish
Build/Branch:  <phase-x / sha>
Platform:      PC / Steam Deck   Players: 2/3/4
Repro steps:   1) ... 2) ... 3) ...
Expected / Actual:
Evidence:      <profiler / log / clip>   Solve-rate impact: <if puzzle>
Root cause / Fix(owner) / Status
```

## 5. Phase gates
- **Phase 2 (this):** stubs compile against imported Fusion; EditMode tests green (collapse/hint/score); architecture review passed.
- **Phase 3 (Sunken Atrium slice):** full loop 2–4p; ≥ 90% first-attempt gate-solve; no light leaks; environment-review green; zero Blocker/Critical open.
- Every PR: QA sign-off; scene PRs also Art/Environment sign-off.

## 6. Tools
Unity Profiler & Frame Debugger, Memory Profiler, ParrelSync (multi-peer), Fusion latency sim, lightmap-leak inspection, automated EditMode/PlayMode in CI (Phase 3), secret-scan (no committed App IDs).
