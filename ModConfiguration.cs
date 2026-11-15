using BepInEx.Configuration;

namespace PKReplayPlus;

public sealed class ModConfiguration
{
    private readonly ConfigFile _config;

    // Suikoden 2 Replay & Post-Game
    public ConfigEntry<bool> LoopCliveQuest { get; private set; }
    public ConfigEntry<bool> LoopFinalBossGauntlet { get; private set; }
    public ConfigEntry<bool> ResetGauntletOnNextEntry { get; private set; }
    public ConfigEntry<bool> EnableLeonaPostFinalBoss { get; private set; }
    public ConfigEntry<bool> EnableCastleMinigamesPostFinalBoss { get; private set; }

    // Guardian Blessing
    public ConfigEntry<bool> EnableRepeatStatueRewards { get; private set; }
    public ConfigEntry<bool> AlwaysKeepStatueAssembled { get; private set; }
    public ConfigEntry<bool> EnableDebugLogging { get; private set; }

    public ModConfiguration(ConfigFile config)
    {
        _config = config;
    }

    public void Init()
    {
        LoopCliveQuest = _config.Bind(
            "01 Replay & Post-Game",
            "LoopCliveQuest",
            true,
            "Automatically resets Clive's pursuit quest back to Lakewest upon entering Lakewest with the Sajah Village finale completed. Allows replaying the complete questline from Lakewest to Sajah indefinitely in the late game."
        );

        LoopFinalBossGauntlet = _config.Bind(
            "01 Replay & Post-Game",
            "LoopFinalBossGauntlet",
            true,
            "Automatically resets the entire L'Renouille final battle gauntlet (General Han Cunningham duel, Lucia & Karaya vanguard battle, Generals Seed & Culgan battle, and Silver Beast Rune final boss) upon entering L'Renouille outer gates (vj01) when the final boss has been defeated. Allows challenging the complete final sequence indefinitely."
        );

        ResetGauntletOnNextEntry = _config.Bind(
            "01 Replay & Post-Game",
            "ResetGauntletOnNextEntry",
            false,
            "When true, forces a complete reset of the L'Renouille final battle gauntlet (Lucia, Han, Seed & Culgan, Beast Rune) the next time any L'Renouille map is entered, even if the final boss has not yet been defeated. Automatically resets back to false after performing the reset."
        );

        EnableLeonaPostFinalBoss = _config.Bind(
            "01 Replay & Post-Game",
            "EnableLeonaPostFinalBoss",
            true,
            "Restores Leona at Dunan Castle Tavern (vk08) after the final boss battle (or whenever party changing is locked by the epilogue), replacing the substitute maid ('Leona went to restock on spirits') and fully re-enabling the party change menu."
        );

        EnableCastleMinigamesPostFinalBoss = _config.Bind(
            "01 Replay & Post-Game",
            "EnableCastleMinigamesPostFinalBoss",
            true,
            "Restores Dunan Castle minigames (such as vk18 Laundry & Gardens) during the post-final-boss epilogue by temporarily clearing epilogue lockout flags while on the map."
        );

        EnableRepeatStatueRewards = _config.Bind(
            "02 Guardian Blessing",
            "EnableRepeatStatueRewards",
            true,
            "When enabled, re-arms the Guardian Deity blessing reward whenever the statue design is rebuilt or altered at Jude's workshop."
        );

        AlwaysKeepStatueAssembled = _config.Bind(
            "02 Guardian Blessing",
            "AlwaysKeepStatueAssembled",
            true,
            "Ensures the Guardian Deity statue maintains its assembled 3D model (parts_no[3] = 1) instead of reverting to plain stone."
        );

        EnableDebugLogging = _config.Bind(
            "03 Diagnostics",
            "EnableDebugLogging",
            false,
            "Enable detailed diagnostics logging for Guardian Deity state transitions and event triggers."
        );
    }
}
