using System;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public event Action<int> Changed;

    public int Value { get; private set; }

    public void Add(int amount)
    {
        if (amount <= 0)
            return;

        Value += amount;
        Changed?.Invoke(Value);
    }
}
