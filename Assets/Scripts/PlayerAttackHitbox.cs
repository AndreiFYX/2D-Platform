using UnityEngine;

public class PlayerAttackHitbox : MonoBehaviour
{
    [SerializeField] private int _damaged = 5;

    private bool _canDamage;

    public void BeginAttack()
    {
        _canDamage = true;
    }

    public void EndAttack()
    {
        _canDamage = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryDamage(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        TryDamage(collision);
    }

    private void TryDamage(Collider2D collider)
    {
        if (!_canDamage)
            return;

        if (collider.TryGetComponent(out DeathEnemy enemyHealth))
        {
            enemyHealth.TakeDamage(_damaged);
            _canDamage = false;            
        }
    }
}