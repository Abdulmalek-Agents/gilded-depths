# Gilded Depths — Art Direction & Environment Standards

**Version:** 1.0 (Phase 2)  ·  **Owner:** Technical Artist + 3D Modelers + Lighting/Environment team (with QA)

## 1. Art direction
- **Style:** stylized-realistic ancient ruins; **light is the lead actor.** Each ruin is an atmospheric set-piece that rewards the descent (the "beauty as reward" pillar).
- **Readability:** glyphs/clues must read clearly when illuminated by the Lantern; interactive elements have a consistent, learnable visual language (subtle gold inlay = Gildfolk mechanism).
- **Asymmetry made visible:** each tool's targets are visually distinct (Lantern-only ink shimmer, Grapple anchors, Brush-able dust, Ledger glyph panels).

## 2. Ruin palettes & mood
| Ruin | Palette | Signature |
|---|---|---|
| Sunken Atrium | teal water + warm lantern | light/water reflections, submerged glyphs |
| Mirror Catacomb | cold silver | reflections/illusions |
| Root Cathedral | green + amber | overgrowth, organic mechanisms |
| Ashfall Forge | charcoal + ember | heat shimmer, metal |
| Tidal Archive | blue + bronze | rising/falling water timing |
| Gilded Vault | gold + black | the capstone reveal |

## 3. Environment dressing standards (QA-enforced)
Every placed asset must pass the **joint QA + Art/Environment review**:
- **Grounding:** no floating/sunken props; contact shadows confirm contact; no unintended clipping.
- **Pivots:** sensible anchor points; clean rotation; no off-origin jitter.
- **Placement intent:** composition leads the eye toward clues/exits; lighting guides navigation; senior-environment-artist quality, not scatter.
- **Materials:** correct variants; no magenta; consistent texel density.
- **Lightmap UVs:** clean non-overlapping UV2; **no light leaks/seams** (critical — lighting is the art).
- **LODs:** smooth transitions, no popping at player distance.
- **Collision:** accurate; no phantom walls; artifacts/players never snag.
- **Occlusion & AO:** occlusion culling baked; AO grounds every prop.
- **Hierarchy:** `_Environment/Ruin/Section/...`; prefabs for repeats; correct static flags.

## 4. Lighting & baking (lead discipline)
- URP baked GI per ruin; Lantern = real-time point light with baked-probe blending; reflection probes per chamber; tight real-time light budget; validate no leaks/seams; mood-first exposure per ruin.

## 5. Optimization
- SRP Batcher; modular-kit GPU instancing; additive section streaming; baked occlusion; capped real-time lights; volumetric density tuned for Deck.

## 6. Pipeline
Greybox (designer authors the PUZZLE first) → dress with ruins kit (modelers) → light/bake (lighting) → **joint QA+Art review** → fix list → re-review → approved → merge. Puzzle function is locked before beautification so art never hides solvability.
