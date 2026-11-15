using UnityEngine.SceneManagement;

namespace PKReplayPlus.Patches;

public static class GameDetection
{
    public static bool IsGSD2()
    {
        return SceneManager.GetActiveScene().name == "GSD2";
    }
}
