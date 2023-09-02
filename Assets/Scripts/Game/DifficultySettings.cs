using UnityEngine;

[CreateAssetMenu(fileName = "New DifficultyData", menuName = "Difficulty Settings", order = 51)]
public class DifficultySettings : ScriptableObject
{
    [SerializeField] private float _playerMovementVelocity;
    [SerializeField] private float _playerTimeLimiterDuration;
    [SerializeField] private float _playerRotationDuration;
    [SerializeField] private float _enemyDelayBetweenMovements;
    
    public float PlayerMovementVelocity => _playerMovementVelocity;
    public float PlayerTimeLimiterDuration => _playerTimeLimiterDuration;
    public float PlayerRotationDuration => _playerRotationDuration;
    public float EnemyDelayBetweenMovements => _enemyDelayBetweenMovements;
}
