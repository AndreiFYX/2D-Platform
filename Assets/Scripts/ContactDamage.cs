using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damage = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health health))
            health.TakeDamage(_damage);
    }
}
