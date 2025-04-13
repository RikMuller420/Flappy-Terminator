using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpSpeed = 10f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpRotationSpeed = 800f;
    [SerializeField] private float _rotationSpeed = 45f;
    [SerializeField] private float _maxRotationZ = 65f;
    [SerializeField] private float _minRotationZ = -60f;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private bool _isRotateToMax;

    private void Awake()
    {
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void FixedUpdate()
    {
        transform.rotation = GetRotation();

        if (_isRotateToMax && transform.rotation == _maxRotation)
        {
            _isRotateToMax = false;
        }
    }

    private Quaternion GetRotation()
    {
        if (_isRotateToMax)
        {
            return Quaternion.RotateTowards(transform.rotation, _maxRotation, _jumpRotationSpeed * Time.deltaTime);
        }
        else
        {
            return Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    public void Jump()
    {
        _rigidbody.linearVelocity = new Vector2(_speed, _jumpSpeed);
        _isRotateToMax = true;
    }

    public void Reset()
    {
        transform.position = Vector2.zero;
        transform.rotation = _maxRotation; 
        Jump();
    }
}
