using TMPro;
using UnityEngine;

public class CoinCounterView : MonoBehaviour
{
    [SerializeField] private CoinCounter _counter;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _counter.Changed += Show;
        Show(_counter.Value);
    }

    private void OnDisable()
    {
        _counter.Changed -= Show;
    }

    private void Show(int value)
    {
        _text.text = value.ToString();
    }
}
