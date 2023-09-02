using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameScreen : MonoBehaviour
{
    [UsedImplicitly]
    public void StartGame() // calling when start game button pushing
    {
        SceneManager.LoadSceneAsync(GlobalConstants.GAME_SCENE);
    }

    [UsedImplicitly]
    public void OpenSettings() // calling when game settings button pushing
    {
        PlayerPrefs.SetInt("SceneIndex", 0);
        SceneManager.LoadSceneAsync(GlobalConstants.GAME_SETTINGS_SCENE);
    }
}
