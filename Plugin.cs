using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using PKReplayPlus.Patches;

namespace PKReplayPlus;

[BepInPlugin("faospark.pkreplayplus", "PKReplayPlus", "1.0.0")]
[BepInDependency("faospark.pkcore", BepInDependency.DependencyFlags.SoftDependency)]
[BepInDependency("d3xMachina.suikoden_fix", BepInDependency.DependencyFlags.SoftDependency)]
public class Plugin : BasePlugin
{
    public static Plugin Instance { get; private set; }
    public static new ManualLogSource Log;
    public static new ModConfiguration Config;

    public override void Load()
    {
        Instance = this;
        Log = base.Log;

        Log.LogInfo("Loading PKReplayPlus...");

        Config = new ModConfiguration(base.Config);
        Config.Init();

        var harmony = new Harmony("faospark.pkreplayplus");

        // Map tracking for quest/boss replay & epilogue restorations
        harmony.PatchAll(typeof(MACHICON_OnMapInitPatch));
        harmony.PatchAll(typeof(MachiLoader_Load_Patch));

        // Epilogue Leona Restoration (Dunan Castle Tavern vk08)
        harmony.PatchAll(typeof(S2LeonaOnMapInitPrefixPatch));
        harmony.PatchAll(typeof(S2LeonaSaveMenuInitPrefixPatch));

        // Epilogue Castle Minigames Restoration (vk18 Laundry & Gardens)
        harmony.PatchAll(typeof(S2MinigameOnMapInitPrefixPatch));
        harmony.PatchAll(typeof(S2MinigameSaveMenuInitPrefixPatch));

        // Guardian Deity Repeatable Rewards & Statue Model Fix
        harmony.PatchAll(typeof(GuardianDeityRepeatRewardsPatch));

        Log.LogInfo("PKReplayPlus loaded successfully!");
    }
}
