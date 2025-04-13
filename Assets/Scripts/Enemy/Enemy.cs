using System;
using UnityEngine;

public class Enemy : PoolableObject, IInteractable
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private EnemyShooter _shooter;

    [SerializeField] private float _appearSpeed = 8f;
    [SerializeField] private float _appearOffsetY = 15f;
    [SerializeField] private float _deadSpeed = 15f;
    [SerializeField] private float _deadOffsetY = -20;
    
    private Transform _player;
    private EnemyMoveBehaviour _moveBehaviour;
    private AppearMoveBehaviour _appearMoveBehaviour;
    private FightMoveBehaviour _fightMoveBehaviour;
    private DyingMoveBehaviour _dyingMoveBehaviour;

    public event Action Destroyed;

    private void Awake()
    {
        EnemyMover enemyMover = new EnemyMover(transform);
        _appearMoveBehaviour = new AppearMoveBehaviour(_appearSpeed, _appearOffsetY,
                                                        OnReachedFightPosition, enemyMover);
        _fightMoveBehaviour = new FightMoveBehaviour(enemyMover);
        _dyingMoveBehaviour = new DyingMoveBehaviour(_deadSpeed, _deadOffsetY,
                                                        OnReachedDeadPosition, enemyMover);
    }

    private void FixedUpdate()
    {
        _moveBehaviour.Move(_player);
    }

    public void Initialize(Func<Bullet> getBulletFunc, Transform player)
    {
        _player = player;
        _shooter.Initialize(getBulletFunc);
    }

    public void Destroy()
    {
        _collider.enabled = false;
        _moveBehaviour = _dyingMoveBehaviour;
        _shooter.StopShooting();
        Destroyed?.Invoke();
    }

    public void Appear(float offsetX, float positionY)
    {
        _collider.enabled = true;

        _appearMoveBehaviour.SetOffsets(offsetX, positionY);
        _fightMoveBehaviour.SetOffsets(offsetX, positionY);
        _dyingMoveBehaviour.SetOffsets(offsetX, positionY);
        _appearMoveBehaviour.LocateInAppearPosition(_player);
        _moveBehaviour = _appearMoveBehaviour;
    }

    private void OnReachedFightPosition()
    {
        _moveBehaviour = _fightMoveBehaviour;
        _shooter.StartShooting();
    }

    private void OnReachedDeadPosition()
    {
        OnDeactivated();
    }
}
