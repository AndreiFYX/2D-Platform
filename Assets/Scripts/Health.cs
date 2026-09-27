using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxHealth = 10;

    public event Action<Health> Died;

    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;
    public bool IsAlive => CurrentHealth > 0;

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0 || !IsAlive)
            return;

        CurrentHealth = Mathf.Max(CurrentHealth - amount, 0);

        if (!IsAlive)
            Died?.Invoke(this);
    }

    public void Heal(int amount)
    {
        if (amount <= 0 || !IsAlive)
            return;

        CurrentHealth = Mathf.Min(CurrentHealth + amount, _maxHealth);
    }
}
