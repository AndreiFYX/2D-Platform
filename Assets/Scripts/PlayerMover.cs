using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputReader), typeof(EntityRotator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _moveSpeed = 5f;
    [SerializeField, Min(0f)] private float _jumpForce = 5f;
    [SerializeField, Min(0f)] private float _groundCheckRadius = 0.1f;
    [SerializeField] private InputReader _input;
    [SerializeField] private EntityRotator _rotator;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidbody; 
    [SerializeField] private bool _isGrounded; // временно видна

    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputReader>();
        _rotator = GetComponent<EntityRotator>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(
            _groundCheck.position,
            _groundCheckRadius,
            _groundLayer);

        _animator.SetBool("isGround", _isGrounded);
    }

    private void Move()
    {
        float direction = _input.Horizontal;
        _rigidbody.linearVelocity = new Vector2(direction * _moveSpeed, _rigidbody.linearVelocity.y);

        if (!Mathf.Approximately(direction, 0f))
            _rotator.Face(direction);

        _animator.SetBool("Walk", !Mathf.Approximately(direction, 0f));
    }

    private void Jump()
    {
        if (!_input.JumpPressed || !_isGrounded)
            return;

        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _animator.SetTrigger("Jump2");
        _animator.SetBool("Walk", false);
    }
}
