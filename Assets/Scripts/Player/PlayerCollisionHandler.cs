using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _enemyDestroyed;
    [SerializeField] private UnityEvent _playerCameStartPoint;
    [SerializeField] private UnityEvent _playerDied;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(GlobalConstants.BORDER_TAG))
        {
            _playerDied.Invoke();
        }

        if (collider.TryGetComponent(out EnemyController enemyController))
        {
            enemyController.Destroy();
            _enemyDestroyed.Invoke();
        }

        if (collider.CompareTag(GlobalConstants.PLAYER_START_POINT_TAG))
        {
            _playerCameStartPoint.Invoke();
        }
    }
}
