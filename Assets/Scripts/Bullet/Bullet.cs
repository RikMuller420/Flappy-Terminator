using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolableObject
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _maxLifetime = 3f;

    private BulletMover _mover;
    private WaitForSeconds _wait;
    private Coroutine _deactivateCoroutine;
    private BulletOwner _owner;

    private readonly Dictionary<System.Type, IBulletHitHandler> _typesHitHandlers = new Dictionary<System.Type, IBulletHitHandler>
    {
        { typeof(Ground),   new GroundHitHandler() },
        { typeof(Enemy),    new EnemyHitHandler() },
        { typeof(Player),   new PlayerHitHandler() }
    };

    public BulletOwner Owner => _owner;

    private void Awake()
    {
        _mover = new BulletMover(transform, _speed);
        _wait = new WaitForSeconds(_maxLifetime);
    }

    private void FixedUpdate()
    {
        _mover.Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            if (_typesHitHandlers.TryGetValue(interactable.GetType(), out IBulletHitHandler hitHanlder))
            {
                hitHanlder.Hit(this, interactable);
            }
        }
    }

    public void Initialize(BulletOwner owner)
    {
        _owner = owner;
        _deactivateCoroutine = StartCoroutine(DeactivateInDelay());
    }

    public void Deactivate()
    {
        if (_deactivateCoroutine != null)
        {
            StopCoroutine(_deactivateCoroutine);
        }

        OnDeactivated();
    }

    private IEnumerator DeactivateInDelay()
    {
        yield return _wait;

        Deactivate();
    }
}
