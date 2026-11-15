# PKReplayPlus

**By [faospark](https://github.com/faospark)**

A standalone **Suikoden II HD Remaster** (BepInEx 6 IL2CPP) plugin combining post-game epilogue restorations, repeatable quest/boss gauntlets, and Guardian Deity repeatable rewards.

## Features

1. **Final Boss Gauntlet Replay (`LoopFinalBossGauntlet`, `ResetGauntletOnNextEntry`)**
   * Automatically resets the 4-stage L'Renouille gauntlet (Lucia & Karaya Vanguard, General Han Cunningham duel, Generals Seed & Culgan, and Silver Beast Rune) upon entering `vj01` after defeating the final boss.
2. **Epilogue Leona Restoration (`EnableLeonaPostFinalBoss`)**
   * Restores Leona and party changing at Dunan Castle Tavern (`vk08`) during the post-final-boss epilogue.
3. **Epilogue Castle Minigames Restoration (`EnableCastleMinigamesPostFinalBoss`)**
   * Restores Dunan Castle minigames (`vk18` Laundry & Gardens) during the post-final-boss epilogue.
4. **Clive's Pursuit Quest Replay (`LoopCliveQuest`)**
   * Automatically resets Clive's pursuit questline back to Lakewest after completing the Sajah Village finale.
5. **Guardian Blessing (`EnableRepeatStatueRewards`, `AlwaysKeepStatueAssembled`)**
   * Re-arms Guardian Deity blessing rewards when rebuilding/altering the statue at Jude's workshop and preserves the assembled 3D statue model.

## Configuration

Settings generate in `BepInEx/config/faospark.pkreplayplus.cfg` on launch.
