using UnityEngine;

public class EnemyMover
{
    public Transform Owner { get; }

    private float _offsetX = 10f;
    private float _positionY = 0f;

    public EnemyMover(Transform enemy)
    {
        Owner = enemy;
    }

    public void SetOffsets(float offsetX, float positionY)
    {
        _offsetX = offsetX;
        _positionY = positionY;
    }

    public void Move(Vector2 position)
    {
        Owner.transform.position = position;
    }

    public Vector2 FightPosition(Transform player)
    {
        return new Vector2(player.position.x + _offsetX, _positionY);
    }
}
