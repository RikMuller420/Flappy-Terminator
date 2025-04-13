using UnityEngine;

public class FightMoveBehaviour : EnemyMoveBehaviour
{
    public FightMoveBehaviour(EnemyMover enemyMover) : base(enemyMover) { }

    public override void Move(Transform player)
    {
        EnemyMover.Move(FightPosition(player));
    }
}
