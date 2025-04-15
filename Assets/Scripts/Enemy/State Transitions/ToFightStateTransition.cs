using UnityEngine;

public class ToFightStateTransition : Transition
{
    private EnemyMover _enemyMover;
    private Transform _player;

    private float _distanceThreshold = 0.1f;

    public ToFightStateTransition(State nextState, Transform player, EnemyMover enemyMover) : base(nextState)
    {
        _player = player;
        _enemyMover = enemyMover;
    }

    protected override bool CanTransit()
    {
        Vector2 targetPosition = _enemyMover.FightPosition(_player);
        float sqrDistance = Vector2.SqrMagnitude((Vector2)_enemyMover.Owner.position - targetPosition);

        return sqrDistance < _distanceThreshold;
    }
}
