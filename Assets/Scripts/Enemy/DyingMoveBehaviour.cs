using System;
using UnityEngine;

public class DyingMoveBehaviour : EnemyMoveBehaviour
{
    private float _deadSpeed = 20;
    private float _deadOffsetY = -20;
    private Action _reachDeadPositionDelegate;

    public DyingMoveBehaviour(float deadSpeed, float deadOffsetY,
                            Action reachDeadPositionDelegate, EnemyMover enemyMover) :
                            base(enemyMover)
    {
        _deadSpeed = deadSpeed;
        _deadOffsetY = deadOffsetY;
        _reachDeadPositionDelegate = reachDeadPositionDelegate;
    }

    public override void Move(Transform player)
    {
        Vector2 targetPosition = FightPosition(player) + new Vector2(0, _deadOffsetY);
        float stepDistance = _deadSpeed * Time.deltaTime;
        EnemyMover.Move(Vector2.MoveTowards(EnemyMover.Owner.position, targetPosition, stepDistance));

        if ((Vector2)EnemyMover.Owner.position == targetPosition)
        {
            _reachDeadPositionDelegate?.Invoke();
        }
    }
}
