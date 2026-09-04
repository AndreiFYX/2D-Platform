using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private Animator _animator;

    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0 || CurrentHealth <= 0)
            return;

        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);
        _maxHealth = CurrentHealth;

        if (CurrentHealth == 0)
            Destroy(gameObject);
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;

        if (amount <= 0)
            return;

        if (CurrentHealth >= _maxHealth)
        {
            if (CurrentHealth > _maxHealth)
                CurrentHealth = _maxHealth;
            return;
        }
    }
}