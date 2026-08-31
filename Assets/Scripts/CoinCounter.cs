using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinScore;

    private int _score;

    public void AddCoins()
    {
        _score++;
        _coinScore.text = _score.ToString();        
    }
}
