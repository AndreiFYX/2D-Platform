using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private Transform _enemyTransform;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private BoxCollider2D[] _boxGround;

    private float _direction = 1f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _enemyTransform.position += Vector3.right * _moveSpeed * _direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponentInParent<MovePlayer>() != null)
        {
            GameEvents.RaiseEnemyTouchedByPlayer(this);
        }

        foreach (var box in _boxGround)
        {
            if (collision == box)
            {
                _direction *= -1f;
                _spriteRenderer.flipX = _direction < 0f;
                break;
            }
        }
    }
}