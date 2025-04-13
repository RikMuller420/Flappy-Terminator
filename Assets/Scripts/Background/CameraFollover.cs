using UnityEngine;

public class CameraFollover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _offsetX;

    private float offsetZ = -10f;

    private void LateUpdate()
    {
        transform.position = _target.position + new Vector3(_offsetX, 0, offsetZ);
    }
}
