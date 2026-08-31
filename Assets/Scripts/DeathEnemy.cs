using UnityEngine;

public class DeathEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MoveEnemy enemy))
        { 
           Destroy(gameObject);
        }
    }
}
