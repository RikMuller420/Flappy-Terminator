using System;
using UnityEngine;

public class AppearMoveBehaviour : EnemyMoveBehaviour
{
    private float _appearSpeed;
    private float _appearOffsetY;
    private Action _reachFightPositionDelegate;

    public AppearMoveBehaviour(float appearSpeed, float appearOffsetY,
                                Action reachFightPositionDelegate, EnemyMover enemyMover) :
                                base(enemyMover)
    {
        _appearSpeed = appearSpeed;
        _appearOffsetY = appearOffsetY;
        _reachFightPositionDelegate = reachFightPositionDelegate;
    }

    public override void Move(Transform player)
    {
        Vector2 targetPosition = FightPosition(player);
        float stepDistance = _appearSpeed * Time.deltaTime;
        EnemyMover.Move(Vector2.MoveTowards(EnemyMover.Owner.position, targetPosition, stepDistance));

        if ((Vector2)EnemyMover.Owner.position == targetPosition)
        {
            _reachFightPositionDelegate?.Invoke();
        }
    }

    public void LocateInAppearPosition(Transform player)
    {
        Vector2 appearPosition = FightPosition(player) + new Vector2(0, _appearOffsetY);
        EnemyMover.Move(appearPosition);
    }
}
