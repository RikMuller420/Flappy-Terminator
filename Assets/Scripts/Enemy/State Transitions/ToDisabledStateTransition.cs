using UnityEngine;

public class ToDisabledStateTransition : Transition
{
    private EnemyMover _enemyMover;
    private Transform _player;
    private float _deadOffsetY = -20;

    private float _distanceThreshold = 0.1f;

    public ToDisabledStateTransition(State nextState, float deadOffsetY, Transform player,
                                    EnemyMover enemyMover) : base(nextState)
    {
        _player = player;
        _enemyMover = enemyMover;
        _deadOffsetY = deadOffsetY;
    }

    protected override bool CanTransit()
    {
        Vector2 targetPosition = _enemyMover.FightPosition(_player) + new Vector2(0, _deadOffsetY);
        float sqrDistance = Vector2.SqrMagnitude((Vector2)_enemyMover.Owner.position - targetPosition);

        return sqrDistance < _distanceThreshold;
    }
}
