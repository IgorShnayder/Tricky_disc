using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _leftSpawnPoint;
    [SerializeField] private Transform _rightSpawnPoint;
    [SerializeField] private EnemyController _enemyPrefab;
    [SerializeField] private float _delayBetweenMovements;
    
    private float _minPointX;
    private float _maxPointX;
    
    private void Awake()
    {
        var camera = Camera.main;
        _minPointX = camera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        _maxPointX = camera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;
    }

    private void Start()
    {
        if (PlayerPrefs.GetFloat("EnemyDelayBetweenMovements") > 0)
        {
            var difficultyLevelDelay = PlayerPrefs.GetFloat("EnemyDelayBetweenMovements");
            _delayBetweenMovements = difficultyLevelDelay;
        }
        
        Spawn();
    }

    private bool ShouldSpawnOnLeftSide()
    {
        var randomSpawn = Random.Range(0, 2);
        return randomSpawn == 1;
    }

    [UsedImplicitly]
    public void Spawn() // calling when player return to start point
    {
        var spawnPoint = ShouldSpawnOnLeftSide() ? _leftSpawnPoint.position : _rightSpawnPoint.position;
        var currentEnemy = Instantiate(_enemyPrefab, spawnPoint, Quaternion.identity, transform);
        currentEnemy.Initialize(_minPointX, _maxPointX, _delayBetweenMovements);
    }
}
