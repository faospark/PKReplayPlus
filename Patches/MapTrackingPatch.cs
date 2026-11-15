extern alias GSD2;

using System;
using HarmonyLib;

namespace PKReplayPlus.Patches;

[HarmonyPatch(typeof(GSD2::MACHICON), "OnMapInit")]
public static class MACHICON_OnMapInitPatch
{
    public static string PreviousMapId = "";
    public static string CurrentMapId = "";

    public static void UpdateCurrentMapId(string newMapId)
    {
        if (string.IsNullOrEmpty(newMapId)) return;
        if (!string.Equals(CurrentMapId, newMapId, StringComparison.OrdinalIgnoreCase))
        {
            PreviousMapId = CurrentMapId;
            CurrentMapId = newMapId;
        }
    }

    [HarmonyPostfix]
    public static void Postfix(GSD2::MACHICON __instance)
    {
        if (__instance == null) return;

        string machiName = __instance.GetMapName();
        string parsedMapId = ParseMapIdFromMachiName(machiName);
        UpdateCurrentMapId(parsedMapId);

        if (!string.IsNullOrEmpty(CurrentMapId))
        {
            S2FinalBossReplayPatch.CheckAndResetFinalBoss(CurrentMapId, PreviousMapId);
        }
    }

    public static string ParseMapIdFromMachiName(string machiName)
    {
        if (string.IsNullOrEmpty(machiName)) return null;

        var parts = machiName.Split(' ');
        if (parts.Length >= 2)
        {
            string basePrefix = parts[0];
            for (int i = 1; i < parts.Length; i++)
            {
                if (parts[i].StartsWith("mno:") && int.TryParse(parts[i].Substring(4), out int mno))
                {
                    return $"{basePrefix}_{mno:D2}";
                }
            }
            return basePrefix;
        }
        return machiName;
    }
}

[HarmonyPatch(typeof(GSD2::MACHICON), "EventInit")]
public static class MachiLoader_Load_Patch
{
    [HarmonyPrefix]
    public static void Prefix(GSD2::MACHICON __instance)
    {
        if (__instance == null) return;

        try
        {
            string machiName = __instance.GetMapName();
            string mapId = MACHICON_OnMapInitPatch.ParseMapIdFromMachiName(machiName) ?? machiName;
            S2CliveQuestReplayPatch.CheckAndResetCliveQuest(mapId);
            S2FinalBossReplayPatch.CheckAndResetFinalBoss(mapId, MACHICON_OnMapInitPatch.CurrentMapId);
            s2EpilogueLeona.ApplyForMap(mapId);
            s2EpilogueMinigame.ApplyForMap(mapId);
        }
        catch (Exception ex)
        {
            Plugin.Log.LogError($"[MapTrackingPatch] Error during EventInit prefix checks: {ex}");
        }
    }

    [HarmonyPostfix]
    public static void Postfix(GSD2::MACHICON __instance)
    {
        if (__instance == null) return;

        try
        {
            string machiName = __instance.GetMapName();
            string mapId = MACHICON_OnMapInitPatch.ParseMapIdFromMachiName(machiName) ?? machiName;
            if (!string.IsNullOrEmpty(mapId))
            {
                MACHICON_OnMapInitPatch.UpdateCurrentMapId(mapId);
            }
        }
        catch { }
    }
}
