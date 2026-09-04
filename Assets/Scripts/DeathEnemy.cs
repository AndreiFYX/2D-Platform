using UnityEngine;

[RequireComponent(typeof(MoveEnemy))]
public class DeathEnemy : MonoBehaviour
{
    [SerializeField] private  int _maxHealth = 10;

    public int CurrentHealth { get; private set; }

    private MoveEnemy _moveEnemy;

    private void Awake()
    {
        CurrentHealth = _maxHealth;
        _moveEnemy = GetComponent<MoveEnemy>();
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0 || CurrentHealth <= 0)
            return;
     
        CurrentHealth = Mathf.Max(CurrentHealth - damage, 0);
        
        if (CurrentHealth == 0)
            GameEvents.RaiseEnemyTouchedByPlayer(_moveEnemy);
    }
}