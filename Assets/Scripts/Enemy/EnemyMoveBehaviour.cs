using UnityEngine;

public abstract class EnemyMoveBehaviour
{
    protected EnemyMover EnemyMover;

    private float _offsetX = 10f;
    private float _positionY = 0f;


    public EnemyMoveBehaviour(EnemyMover enemyMover)
    {
        EnemyMover = enemyMover;
    }

    public abstract void Move(Transform player);

    public void SetOffsets(float offsetX, float positionY)
    {
        _offsetX = offsetX;
        _positionY = positionY;
    }

    protected Vector2 FightPosition(Transform player)
    {
        return new Vector2(player.position.x + _offsetX, _positionY);
    }
}
