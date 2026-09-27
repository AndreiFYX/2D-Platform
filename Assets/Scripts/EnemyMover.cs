using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _movementTarget;
    [SerializeField, Min(0f)] private float _moveSpeed = 2f;
    [SerializeField] private Collider2D[] _turnAroundColliders;
    [SerializeField] private EntityRotator _rotator;

    private float _direction = 1f;

    private void Awake()
    {
        _movementTarget ??= transform;
        _rotator ??= GetComponent<EntityRotator>();
    }

    private void Update()
    {
        _movementTarget.position += Vector3.right * _moveSpeed * _direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (Collider2D turnAroundCollider in _turnAroundColliders)
        {
            if (other != turnAroundCollider)
                continue;

            _direction *= -1f;
            if (_rotator != null)
                _rotator.Face(_direction);
            return;
        }
    }
}
