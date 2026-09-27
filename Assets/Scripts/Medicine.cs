using UnityEngine;

public class Medicine : MonoBehaviour
{
    [SerializeField, Min(1)] private int _healAmount = 10;

    public int HealAmount => _healAmount;
}
