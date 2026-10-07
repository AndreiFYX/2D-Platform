using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputReader), typeof(EntityRotator))]
[RequireComponent (typeof(GroundChecker), typeof(PlayerAnimator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _moveSpeed = 5f;
    [SerializeField, Min(0f)] private float _jumpForce = 5f;
    [SerializeField] private InputReader _input;
    [SerializeField] private EntityRotator _rotator;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerAnimator _playerAnimator;
        
    private Rigidbody2D _rigidbody;
    private float _direction;

    public bool isGround => _groundChecker.IsGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputReader>();
        _rotator = GetComponent<EntityRotator>();
        _groundChecker = GetComponent<GroundChecker>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void OnEnable()
    {
        _input.MovementChanged += OnMovementChanged;
        _input.JumpPressed += OnJumpPressed;
    }

    private void OnDisable()
    {
        _input.MovementChanged -= OnMovementChanged;
        _input.JumpPressed -= OnJumpPressed;
    }

    private void FixedUpdate()
    {
        Move();

        _playerAnimator.SetGrounded(isGround);
        _playerAnimator.SetWalking(!Mathf.Approximately(_direction, 0f));
    }

    private void OnMovementChanged(float direction)
    {
        _direction = direction;

        if (!Mathf.Approximately(direction, 0f))
            _rotator.Face(_direction);
    }

    private void OnJumpPressed()
    {
        if (!isGround)
            return;

        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _playerAnimator.PlayJump();
        _playerAnimator.SetWalking(false);
    }

    private void Move()
    {
        _rigidbody.linearVelocity = new Vector2(_direction * _moveSpeed, _rigidbody.linearVelocity.y);
    }
}
