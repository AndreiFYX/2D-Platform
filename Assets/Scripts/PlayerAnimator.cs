using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent (typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private static readonly int IsGroundHash = Animator.StringToHash("isGround");
    private static readonly int WalkHash = Animator.StringToHash("Walk");
    private static readonly int JumpHash = Animator.StringToHash("Jump");
    private static readonly int AttackHash = Animator.StringToHash("Attack1");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetGrounded(bool isGrounded)
    {
        _animator.SetBool(IsGroundHash, isGrounded);
    }

    public void SetWalking(bool isWalking)
    {
        _animator.SetBool(WalkHash, isWalking);
    }

    public void PlayJump()
    {
        _animator.SetTrigger(JumpHash);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(AttackHash);
    }
}
