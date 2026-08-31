using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinCounter _coinCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MovePlayer player))
        {
            _coinCounter.AddCoins();
            Destroy(gameObject);
        }
    }
}
