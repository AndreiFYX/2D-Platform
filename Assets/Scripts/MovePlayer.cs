using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Transform _player;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckRadius = 0.1f;
    [SerializeField] private PlayerAttackHitbox _attackHitbox;
    [SerializeField] private float _attackDuration = 1.25f;

    private Rigidbody2D _rigidbody2D;
    private int _idleSpeed = 0;

    private bool _isGrounded;
    private bool _isAttacking;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
        Attack();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(
            _groundCheck.position,
            _groundCheckRadius,
            _groundLayer);
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody2D.linearVelocity = new Vector2(_moveSpeed, _rigidbody2D.linearVelocity.y);
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _rigidbody2D.linearVelocity = new Vector2(-_moveSpeed, _rigidbody2D.linearVelocity.y);
            _spriteRenderer.flipX = true;
        }
        else
        {
            _rigidbody2D.linearVelocity = new Vector2(_idleSpeed, _rigidbody2D.linearVelocity.y);
        }

        _animator.SetBool("Walk", !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)));
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _animator.SetTrigger("Jump2");
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isGrounded && !_isAttacking)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    private IEnumerator AttackRoutine()
    {
        _isAttacking = true;

        _animator.SetTrigger("Attack1");
        _attackHitbox.BeginAttack();

        yield return new WaitForSeconds(_attackDuration);

        _attackHitbox.EndAttack();
        _isAttacking = false;
    }
}