# PKReplayPlus

**By [faospark](https://github.com/faospark)**

A standalone **Suikoden II HD Remaster** (BepInEx 6 IL2CPP) plugin combining post-game epilogue restorations, repeatable quest/boss gauntlets, and Guardian Deity repeatable rewards.

## Features

1. **Final Boss Gauntlet Replay (`LoopFinalBossGauntlet`, `ResetGauntletOnNextEntry`)**
   * Automatically resets the 4-stage L'Renouille gauntlet (Lucia & Highland Soldiers, General Han Cunningham duel, Generals Seed & Culgan, and Silver Beast Rune) upon entering `vj01` after defeating the final boss.
2. **Epilogue Leona Restoration (`EnableLeonaPostFinalBoss`)**
   * Restores Leona and party changing at Dunan Castle Tavern (`vk08`) during the post-final-boss epilogue.
3. **Epilogue Castle Minigames Restoration (`EnableCastleMinigamesPostFinalBoss`)**
   * Restores Dunan Castle minigames (`vk18` Laundry & Gardens) during the post-final-boss epilogue.
4. **Clive's Pursuit Quest Replay (`LoopCliveQuest`)**
   * Automatically resets Clive's pursuit questline back to Lakewest after completing the Sajah Village finale.
5. **Guardian Blessing (`EnableRepeatStatueRewards`, `AlwaysKeepStatueAssembled`)**
   * Re-arms Guardian Deity blessing rewards when rebuilding/altering the statue at Jude's workshop and preserves the assembled 3D statue model.

## Requirements

- **BepInEx 6.0.0-pre.2 IL2CPP**
- **Suikoden I & II HD Remaster**
- **Recommended:** [Suikoden Fix](https://github.com/d3xMachina/SuikodenFix) by d3xMachina

## Installation

1. Install [BepInEx 6.0 (Unity IL2CPP x64)](https://github.com/BepInEx/BepInEx/releases/download/v6.0.0-pre.2/BepInEx-Unity.IL2CPP-win-x64-6.0.0-pre.2.zip) into your game root directory.
2. Place `PKReplayPlus.dll` into `BepInEx/plugins/`.
3. Launch the game once to generate `BepInEx/config/faospark.pkreplayplus.cfg`.

## Credits & License

- **[faospark](https://github.com/faospark)** — Primary Author & Lead Researcher
- **[d3xMachina](https://github.com/d3xMachina/Suikoden-Fix)** — Creator of Suikoden-Fix & BepInEx IL2CPP foundation
- **[asilverthorn](https://github.com/asilverthorn/suikoden_ref)** — Reference tables and internal IDs
- **Mod Suite:** [Project Kyaro](https://www.nexusmods.com/suikoden1and2hdremaster/mods/6)
- **Framework:** [BepInEx](https://github.com/BepInEx/BepInEx) & [HarmonyX](https://github.com/BepInEx/HarmonyX)

Distributed under the MIT License.
