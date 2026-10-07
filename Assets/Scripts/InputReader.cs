using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action<float> MovementChanged;
    public event Action JumpPressed;
    public event Action AttackPressed;

    private float _previousHorizontal;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (!Mathf.Approximately(horizontal, _previousHorizontal))
        {
            _previousHorizontal = horizontal;
            MovementChanged?.Invoke(horizontal);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        { 
            JumpPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            AttackPressed?.Invoke();
        }
    }
}