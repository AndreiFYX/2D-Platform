using UnityEngine;

public class GameDistributor : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.EnemyTouchedByPlayer += DestroyEnemy;
    }

    private void OnDisable()
    {
        GameEvents.EnemyTouchedByPlayer -= DestroyEnemy;
    }

    private void DestroyEnemy(MoveEnemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}
