using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private Rigidbody2D _rigidbody;
   [SerializeField] private float _movementVelocity;
   [SerializeField] private SpriteRenderer _aimSprite;
   [SerializeField] private PlayerRotator _playerRotator;
   [SerializeField] private UserMoveTimeLimiter _userMoveTimeLimiter;
   [SerializeField] private AudioSource _moveAudioClip;
   [SerializeField] private ParticleSystem _deathParticlePrefab;
   
   private Vector3 _startPosition;
   private bool _isMoving;
   
   private void Awake()
   {
      _startPosition = transform.position;
      _isMoving = false;
   }

   private void Start()
   {
      if (PlayerPrefs.GetFloat("PlayerMovementVelocity") > 0)
      {
         var difficultyLevelVelocity = PlayerPrefs.GetFloat("PlayerMovementVelocity");
         _movementVelocity = difficultyLevelVelocity;
      }
   }

   [UsedImplicitly]
   public void Move() // calling through the move button click callback 
   {
      if (!_isMoving)
      {
         _isMoving = !_isMoving;
         _aimSprite.enabled = false;
         _playerRotator.StopRotation();
         _userMoveTimeLimiter.StopTimeLimiter();
         _moveAudioClip.Play();
         
         _rigidbody.velocity = transform.up * _movementVelocity;
      }
   }

   [UsedImplicitly] 
   public void ChangeDirection() // calling through the event player collision with enemy
   {
      _rigidbody.velocity *= -1;
   }

   [UsedImplicitly]
   public void ResetPosition() // calling through the event player come back to start position trigger
   {
      if (_isMoving)
      {
         _isMoving = !_isMoving;
         _aimSprite.enabled = true;
         _playerRotator.StartRotation();
         _userMoveTimeLimiter.RestartTimeLimiter();
         
         _rigidbody.velocity = Vector2.zero;
         transform.position = _startPosition;
      }
   }

   [UsedImplicitly]
   public void OnPlayerDied() // calling when player died
   {
      Instantiate(_deathParticlePrefab, transform.position, Quaternion.identity);
      Destroy(gameObject);
   }
}
