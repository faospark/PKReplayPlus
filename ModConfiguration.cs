using BepInEx.Configuration;

namespace PKReplayPlus;

public sealed class ModConfiguration
{
    private readonly ConfigFile _config;

    // Suikoden 2 Replay & Post-Game
    public ConfigEntry<bool> LoopCliveQuest { get; private set; }
    public ConfigEntry<bool> LoopFinalBossGauntlet { get; private set; }
    public ConfigEntry<bool> ResetGauntletOnNextEntry { get; private set; }
    public ConfigEntry<bool> ReplayHighlandGuards { get; private set; }
    public ConfigEntry<bool> ReplayHanCunningham { get; private set; }
    public ConfigEntry<bool> ReplayLucia { get; private set; }
    public ConfigEntry<bool> ReplaySeedAndCulgan { get; private set; }
    public ConfigEntry<bool> ReplayBeastRune { get; private set; }
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
            "Automatically resets enabled L'Renouille encounters upon entering L'Renouille outer gates (vj01) when the final boss has been defeated. Use the individual Replay* toggles below to choose which encounters reset."
        );

        ResetGauntletOnNextEntry = _config.Bind(
            "01 Replay & Post-Game",
            "ResetGauntletOnNextEntry",
            false,
            "When true, forces a reset of all enabled L'Renouille encounters the next time any L'Renouille map is entered, even if the final boss has not yet been defeated. Automatically resets back to false after performing the reset."
        );

        ReplayHighlandGuards = _config.Bind(
            "01 Replay & Post-Game",
            "ReplayHighlandGuards",
            false,
            "Include the castle-wide Highland Soldier guard ambushes and outer gate assault segments when resetting L'Renouille."
        );

        ReplayHanCunningham = _config.Bind(
            "01 Replay & Post-Game",
            "ReplayHanCunningham",
            true,
            "Include the General Han Cunningham 1v1 duel at the Outer Fortress Gates (vj01) when resetting L'Renouille."
        );

        ReplayLucia = _config.Bind(
            "01 Replay & Post-Game",
            "ReplayLucia",
            true,
            "Include the Lucia 6v6 boss battle in the 2F Keep (vj02) when resetting L'Renouille."
        );

        ReplaySeedAndCulgan = _config.Bind(
            "01 Replay & Post-Game",
            "ReplaySeedAndCulgan",
            true,
            "Include the Generals Seed & Culgan 6v2 boss battle in the Sanctum Hallway (vj07) when resetting L'Renouille."
        );

        ReplayBeastRune = _config.Bind(
            "01 Replay & Post-Game",
            "ReplayBeastRune",
            true,
            "Include the Silver Beast Rune final boss battle in the Inner Sanctum (vj08) when resetting L'Renouille."
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
