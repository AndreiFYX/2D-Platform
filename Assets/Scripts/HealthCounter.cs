using TMPro;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _medicineScore;
    [SerializeField] private GameObject _medicinePrefab;

    private int _score;
    
    public void AddMedicineHalp()
    {
        _score++;       
        _medicineScore.text = _score.ToString();
    }
}
