using UnityEngine;

public class FightState : State
{
    private EnemyMover _enemyMover;
    private Transform _player;
    private EnemyShooter _shooter;

    public FightState(IStateChanger stateChanger, EnemyMover enemyMover, EnemyShooter shooter,
                    Transform player) : base(stateChanger)
    {
        _enemyMover = enemyMover;
        _player = player;
        _shooter = shooter;
    }

    public override void Enter()
    {
        _shooter.StartShooting();
    }

    public override void Exit()
    {
        _shooter.StopShooting();
    }

    protected override void OnUpdate()
    {
        _enemyMover.Move(_enemyMover.FightPosition(_player));
    }
}
