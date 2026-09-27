using UnityEngine;

public class EntityRotator : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Awake()
    {
        if (_target == null)
            _target = transform;
    }

    public void Face(float direction)
    {
        if (Mathf.Approximately(direction, 0f))
            return;

        _target.localRotation = Quaternion.Euler(0f, direction < 0f ? 180f : 0f, 0f);
    }
}
