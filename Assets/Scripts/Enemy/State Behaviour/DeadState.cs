using UnityEngine;

public class DeadState : State
{
    private float _deadSpeed = 20;
    private float _deadOffsetY = -20;
    private EnemyMover _enemyMover;
    private Transform _player;
    private Collider2D _collider;

    public DeadState(IStateChanger stateChanger, float deadSpeed, float deadOffsetY,
                    Collider2D collider, EnemyMover enemyMover, Transform player) : base(stateChanger)
    {
        _deadSpeed = deadSpeed;
        _deadOffsetY = deadOffsetY;
        _enemyMover = enemyMover;
        _player = player;
        _collider = collider;
    }

    public override void Enter()
    {
        _collider.enabled = false;
    }

    protected override void OnUpdate()
    {
        Vector2 targetPosition = _enemyMover.FightPosition(_player) + new Vector2(0, _deadOffsetY);
        float stepDistance = _deadSpeed * Time.deltaTime;
        _enemyMover.Move(Vector2.MoveTowards(_enemyMover.Owner.position, targetPosition, stepDistance));
    }
}
