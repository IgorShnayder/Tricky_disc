using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _minAngleZ;
    [SerializeField] private float _maxAngleZ;
    
    private Quaternion _quaternionMinAngleZ;
    private Quaternion _quaternionMaxAngleZ;
    private float _currentTime;
    private bool _canRotate;

    private void Awake()
    {
        _canRotate = true;
        _quaternionMinAngleZ = Quaternion.Euler(0f, 0f, _minAngleZ);
        _quaternionMaxAngleZ = Quaternion.Euler(0f, 0f, _maxAngleZ);
    }
    
    private void Start()
    {
        if (PlayerPrefs.GetFloat("PlayerRotationDuration") > 0)
        {
            var difficultyLevelDuration = PlayerPrefs.GetFloat("PlayerRotationDuration");
            _duration = difficultyLevelDuration;
        }
    }
    
    private void Update()
    {
        if (_canRotate)
        {
            Rotate();
        }
    }

    public void StartRotation()
    {
        _canRotate = true;
    }

    public void StopRotation()
    {
        _canRotate = false;
    }

    private void Rotate()
    {
        _currentTime += Time.deltaTime;
        var progress = Mathf.PingPong(_currentTime, _duration) / _duration;
        
        transform.rotation = Quaternion.Lerp(_quaternionMinAngleZ, _quaternionMaxAngleZ, progress);
    }
}
