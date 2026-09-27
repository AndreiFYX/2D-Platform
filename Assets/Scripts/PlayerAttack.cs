using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Animator))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerAttackHitbox _hitbox;
    [SerializeField] private Animator _animator;
    [SerializeField, Min(0f)] private float _duration = 1f;

    private bool _isAttacking;

    private void Awake()
    {
        if (_input == null) 
            _input = GetComponent<InputReader>();
        
        if (_mover == null)
            _mover = GetComponent<PlayerMover>();
        
        if (_animator == null)
            _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_input.AttackPressed && _mover.IsGrounded && !_isAttacking)
            StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        _isAttacking = true;
        _animator.SetTrigger("Attack1");
        _hitbox.BeginAttack();

        yield return new WaitForSeconds(_duration);

        _hitbox.EndAttack();
        _isAttacking = false;
    }
}
