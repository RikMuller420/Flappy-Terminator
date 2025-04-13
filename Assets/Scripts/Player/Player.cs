using System;
using UnityEngine;

public class Player : MonoBehaviour, IInteractable
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerShooter _shooter;
    [SerializeField] private GroundCollisionHandler _collisionHandler;

    private bool _isJumpPressed;

    public event Action Destoyed;

    private void OnEnable()
    {
        _inputHandler.JumpPressed += RegisterJumpPressed;
        _inputHandler.ShootPressed += _shooter.TryShoot;
        _collisionHandler.CollisionDetected += Destroy;
    }

    private void OnDisable()
    {
        _inputHandler.JumpPressed -= RegisterJumpPressed;
        _inputHandler.ShootPressed -= _shooter.TryShoot;
        _collisionHandler.CollisionDetected -= Destroy;
    }

    private void FixedUpdate()
    {
        if (_isJumpPressed)
        {
            _mover.Jump();
            _isJumpPressed = false;
        }
    }

    public void Initialize(Func<Bullet> getBulletFunc)
    {
        _shooter.Initialize(getBulletFunc);
    }

    public void Destroy()
    {
        Destoyed?.Invoke();
    }

    public void Restart()
    {
        _mover.Reset();
    }

    private void RegisterJumpPressed()
    {
        _isJumpPressed = true;
    }
}
