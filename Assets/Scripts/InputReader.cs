using UnityEngine;

public class InputReader : MonoBehaviour
{
    public float Horizontal => Input.GetAxisRaw("Horizontal");
    public bool JumpPressed => Input.GetKeyDown(KeyCode.Space);
    public bool AttackPressed => Input.GetKeyDown(KeyCode.F);
}