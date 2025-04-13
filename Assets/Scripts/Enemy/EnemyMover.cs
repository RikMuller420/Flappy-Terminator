using UnityEngine;

public class EnemyMover
{
    public Transform Owner { get; }

    public EnemyMover(Transform enemy)
    {
        Owner = enemy;
    }

    public void Move(Vector2 position)
    {
        Owner.transform.position = position;
    }
}
