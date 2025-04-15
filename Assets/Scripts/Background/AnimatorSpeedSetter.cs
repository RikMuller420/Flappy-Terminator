using UnityEngine;

public class AnimatorSpeedSetter : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed = 0.1f;

    private void Awake()
    {
        _animator.speed = _speed;
    }
}
