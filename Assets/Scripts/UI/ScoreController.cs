using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreLaberl;
    [SerializeField] private int _rewardPerEnemy;
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _scaleFactor;
    [SerializeField] private AudioSource _scoreChangeAudioClip;

    private int _score;

    private void Awake()
    {
        _scoreLaberl.text = "0";
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(GlobalConstants.SCORE_PREFS_KEY, _score);
        PlayerPrefs.Save();
    }

    public void AddScore()
    {
        _score += _rewardPerEnemy; 
        _scoreChangeAudioClip.Play();
        
        _scoreLaberl.text = _score.ToString();
        _scoreLaberl.transform
            .DOPunchScale(Vector3.one * _scaleFactor, _animationDuration, 0)
            .OnComplete(() => _scoreLaberl.transform.localScale = Vector3.one);
    }
}
