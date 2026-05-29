# Gilded Depths — Unity Asset Store & Package Integration Plan

**Version:** 1.0 (Phase 2)  ·  **Owner:** Unity Asset Store Integration Experts + Package/Dependency Experts

> Every package evaluated for **license compatibility, performance cost, and conflict-free integration** before adoption. Confirm current terms at purchase.

## Networking & online
| Package | Tier | Cost | Purpose | Notes |
|---|---|---|---|---|
| **Photon Fusion 2 SDK** | Core | Free tier + paid CCU | Shared-Mode state sync + matchmaking | App ID in `PhotonAppSettings` (gitignored). Choose ONE high-level netcode (no Mirror/NGO alongside). |
| **Photon Voice 2** | Core | Free tier + paid CCU | Positional push-to-talk VOIP | Integrates with Fusion; the design depends on it. |

## Art & environment (the bulk of paid spend)
| Package | Tier | Cost | Purpose | Notes |
|---|---|---|---|---|
| **Modular ancient-ruins / dungeon kits** (e.g. POLYGON Dungeon, or a realistic modular ruins pack) | Core | Paid | The 6 ruins, built from modular pieces | Pick ONE coherent art language; verify clean lightmap UVs + sensible pivots (QA-Art pass). |
| **Sci-fi/ancient prop & decal packs** | Recommended | Paid | Glyphs, murals, mechanisms, artifacts | Glyph art must be language-agnostic (design rule). |
| **Volumetric fog / atmospheric lighting** (e.g. a URP volumetric pack) | Recommended | Paid | The signature "awe" atmosphere | Profile cost on Deck; cap density. |
| **Stylized water (URP)** | Optional | Paid | Sunken Atrium / Tidal Archive | Reflection cost — use planar reflections sparingly. |

## Tools, audio & feel
| Package | Tier | Cost | Purpose | Notes |
|---|---|---|---|---|
| **DOTween Pro** | Recommended | Paid | Mechanism/reveal/escape sequence tweening | Lightweight. |
| **FMOD for Unity** | Recommended | Free (rev-based lic.) | Reactive ambience (collapse tension) | Confirm indie tier. |
| **Easy Save 3** | Recommended | Paid | Local save (lore/cosmetics/best-times/settings) | Robust. |
| **Dialogue/journal system** (optional) | Optional | Paid | Ledger journal + lore tablets UI | Or hand-roll with TMP. |

## Integration rules (conflict-free)
1. **One high-level netcode only** (Fusion 2). Never import Mirror/NGO alongside.
2. Isolate each pack under `Assets/ThirdParty/<Vendor>/`; never overwrite URP asset / Input actions / Tags & Layers.
3. Pin & record versions here on adoption; re-run EditMode tests after each import.
4. Strip demo scenes/scripts before shipping.
5. Never commit Photon App IDs or any secret (gitignored); QA + secret-scan on each phase.
6. License ledger maintained here; no incompatible licenses in the shipped client.

## Estimated paid-asset budget
Low hundreds of USD one-time (ruins kit + atmosphere pack dominate). Thesis: **buy the ruins kit + atmosphere, build the asymmetric-puzzle systems.**
