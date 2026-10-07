using UnityEngine;

[RequireComponent (typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private static readonly int WalkHash = Animator.StringToHash("Blinking");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetWalking(bool isWalking)
    {
        _animator.SetBool(WalkHash, isWalking);
    }
}
