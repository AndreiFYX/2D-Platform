using UnityEngine;

public class Medicine : MonoBehaviour
{
    [SerializeField] private int _halp = 10;
     
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.TryGetComponent(out MovePlayer player))
        {            
            if (collision.TryGetComponent(out HealthPlayer healthPlayer))
            {               
                healthPlayer.Heal(_halp);
            }
            
            Destroy(gameObject);
        }
    }
}