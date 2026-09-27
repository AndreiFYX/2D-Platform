using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(CoinCounter))]
public class CoinCollector : MonoBehaviour
{
    [SerializeField] private CoinCounter _counter;

    private void Awake()
    {
        _counter ??= GetComponent<CoinCounter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out Coin coin))
            return;

        _counter.Add(coin.Value);
        Destroy(coin.gameObject);
    }
}
