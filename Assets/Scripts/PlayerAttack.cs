using System.Collections;
using Unity.VisualScripting;
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
   
    private bool _isAttackFinished;
    private bool _isAttacking;

    private void Awake()
    {
        if (_input == null)
            _input = GetComponent<InputReader>();

        if (_mover == null)
            _mover = GetComponent<PlayerMover>();

        if (_animator == null)
            _animator = GetComponent<Animator>();

        if( _hitbox == null)
            _hitbox = GetComponent<PlayerAttackHitbox>();
    }

    private void Update()
    {
        if (_input.JumpPressed && !_isAttacking)
            StopAllCoroutines();
       
        _isAttacking = false;
        _isAttackFinished = false;
        _hitbox.EndAttack();

        if(_input.AttackPressed && !_isAttacking) 
            StartCoroutine(AttackRoutine());
    }  

    private IEnumerator AttackRoutine()
    {
        _isAttacking = true;
        _isAttackFinished = false;
        _animator.SetTrigger("Attack1");

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
    }
}