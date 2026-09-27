using System.Collections;
using UnityEngine;

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
        _input ??= GetComponent<InputReader>();
        _mover ??= GetComponent<PlayerMover>();
        _animator ??= GetComponent<Animator>();
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
