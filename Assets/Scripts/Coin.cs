using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField, Min(1)] private int _value = 1;

    public int Value => _value;
}
