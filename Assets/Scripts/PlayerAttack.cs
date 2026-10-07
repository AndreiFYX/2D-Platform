using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private PlayerAttackHitbox _hitbox;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private bool _isAttackFinished = true;
    private bool _isAttacking;

    private void Awake()
    {
        _input = GetComponent<InputReader>();
        _playerAnimator = GetComponent<PlayerAnimator>();

        if (_hitbox == null)
            _hitbox = GetComponent<PlayerAttackHitbox>();
    }

    private void OnEnable()
    {
        _input.AttackPressed += OnAttackPressed;
    }

    private void OnDisable()
    {
        _input.AttackPressed -= OnAttackPressed;
        _hitbox.EndAttack();
        _isAttackFinished = true;
        _isAttacking = false;
    }

    private void OnAttackPressed()
    {
        if (_isAttacking)
            return;

        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        _isAttacking = true;
        _isAttackFinished = false;
        _playerAnimator.PlayAttack();

        yield return new WaitUntil(() => _isAttackFinished);

        _isAttacking = false;
    } 

    public void OnAttackBegin()
    {
        _hitbox.BeginAttack();
    }

    public void OnAttackEnd()
    {
        _hitbox.EndAttack();
        _isAttackFinished = true;
    }
}