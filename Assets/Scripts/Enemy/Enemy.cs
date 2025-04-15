using System;
using UnityEngine;

public class Enemy : PoolableObject, IInteractable
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private EnemyShooter _shooter;
    [SerializeField] private EnemyStateMachineCreator stateMachineFactory;

    private EnemyMover _enemyMover;
    private StateMachine _stateMachine;

    private Action _changeStateToAppear;
    private Action _changeStateToDead;

    public event Action Destroyed;

    private void FixedUpdate()
    {
        _stateMachine?.Update();
    }

    public void Initialize(Func<Bullet> getBulletFunc, Transform player)
    {
        _enemyMover = new EnemyMover(transform);
        _shooter.Initialize(getBulletFunc);
        _stateMachine = stateMachineFactory.Create(_enemyMover, player, _collider, _shooter,
                                                  OnDeactivated, out _changeStateToAppear,
                                                  out _changeStateToDead);
    }

    public void Appear(float offsetX, float positionY)
    {
        _enemyMover.SetOffsets(offsetX, positionY);
        _changeStateToAppear?.Invoke();
    }

    public void Destroy()
    {
        _changeStateToDead?.Invoke();
        Destroyed?.Invoke();
    }
}
