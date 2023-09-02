using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class GameDifficultyManager : MonoBehaviour
{
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _scaleFactor;
    [SerializeField] private Button _easyButton;
    [SerializeField] private Button _normalButton;
    [SerializeField] private Button _hardButton;
    [SerializeField] private DifficultySettings[] _gameDifficultySettings;
    
    private int _index;
    
    [UsedImplicitly]
    public void SetEasyDifficulty() // calling when player pushing game difficulty level button on game settings page
    {
        _index = 0;
        PushButtonAnimation(_easyButton);
        ClickOnButton(_gameDifficultySettings[_index]);
    }
    
    [UsedImplicitly]
    public void SetNormalDifficulty() // calling when player pushing game difficulty level button on game settings page
    {
        _index = 1;
        PushButtonAnimation(_normalButton);
        ClickOnButton(_gameDifficultySettings[_index]);
    }
    
    [UsedImplicitly]
    public void SetHardDifficulty() // calling when player pushing game difficulty level button on game settings page
    {
        _index = 2;
        PushButtonAnimation(_hardButton);
        ClickOnButton(_gameDifficultySettings[_index]);
    }

    private void ClickOnButton(DifficultySettings difficultySettings)
    {
        PlayerPrefs.SetFloat("PlayerMovementVelocity", difficultySettings.PlayerMovementVelocity);
        PlayerPrefs.SetFloat("PlayerRotationDuration", difficultySettings.PlayerRotationDuration);
        PlayerPrefs.SetFloat("PlayerTimeLimiterDuration", difficultySettings.PlayerTimeLimiterDuration);
        PlayerPrefs.SetFloat("EnemyDelayBetweenMovements", difficultySettings.EnemyDelayBetweenMovements);
    }
    
    [UsedImplicitly]
    public void ReturnToStartOrGameOverScreen() // calling when player pushing back button on game settings page
    {
        var sceneIndex = PlayerPrefs.GetInt("SceneIndex");
        SceneManager.LoadSceneAsync(sceneIndex == 0 ? GlobalConstants.START_SCENE : GlobalConstants.GAME_OVER_SCENE);
    }
    
    private void PushButtonAnimation(Button button)
    {
        button.transform
            .DOPunchScale(Vector3.one * _scaleFactor, _animationDuration, 0)
            .OnComplete(() => button.transform.localScale = Vector3.one);
    }
}
