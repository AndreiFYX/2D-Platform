using UnityEngine;

[RequireComponent(typeof(Health))]
public class MedicineCollector : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out Medicine medicine))
            return;

        _health.Heal(medicine.HealAmount);
        Destroy(medicine.gameObject);
    }
}
