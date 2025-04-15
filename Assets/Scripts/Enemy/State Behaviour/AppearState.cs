using UnityEngine;

public class AppearState : State
{
    private float _appearSpeed;
    private float _appearOffsetY;
    private EnemyMover _enemyMover;
    private Transform _player;
    private Collider2D _collider;

    public AppearState(IStateChanger stateChanger, float appearSpeed, float appearOffsetY,
                        Collider2D collider, EnemyMover enemyMover, Transform player) : base(stateChanger)
    {
        _collider = collider;
        _appearSpeed = appearSpeed;
        _appearOffsetY = appearOffsetY;
        _enemyMover = enemyMover;
        _player = player;
    }

    public override void Enter()
    {
        _collider.enabled = true;
        Vector2 appearPosition = _enemyMover.FightPosition(_player) + new Vector2(0, _appearOffsetY);
        _enemyMover.Move(appearPosition);
    }

    protected override void OnUpdate()
    {
        Vector2 targetPosition = _enemyMover.FightPosition(_player);
        float stepDistance = _appearSpeed * Time.deltaTime;
        _enemyMover.Move(Vector2.MoveTowards(_enemyMover.Owner.position, targetPosition, stepDistance));
    }
}
