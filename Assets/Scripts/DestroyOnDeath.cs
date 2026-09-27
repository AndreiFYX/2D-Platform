using UnityEngine;

[RequireComponent(typeof(Health))]
public class DestroyOnDeath : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Died += DestroySelf;
    }

    private void OnDisable()
    {
        _health.Died -= DestroySelf;
    }

    private void DestroySelf(Health health)
    {
        Destroy(gameObject);
    }
}
