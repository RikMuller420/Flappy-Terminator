using System.Collections;
using UnityEngine;

public class Bullet : PoolableObject
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _maxLifetime = 3f;

    private BulletMover _mover;
    private WaitForSeconds _wait;
    private Coroutine _deactivateCoroutine;
    private BulletOwner _owner;

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
            switch (interactable)
            {
                case Ground ground:
                    Deactivate();
                    break;

                case Enemy enemy:
                    HitEnemy(enemy);
                    break;

                case Player player:
                    HitPlayer(player);
                    break;
            }
        }
    }

    public void Initialize(BulletOwner owner)
    {
        _owner = owner;
        _deactivateCoroutine = StartCoroutine(DeactivateInDelay());
    }

    private void HitEnemy(Enemy enemy)
    {
        if (_owner == BulletOwner.Player)
        {
            enemy.Destroy();
            Deactivate();
        }
    }

    private void HitPlayer(Player player)
    {
        if (_owner == BulletOwner.Enemy)
        {
            player.Destroy();
            Deactivate();
        }
    }

    private IEnumerator DeactivateInDelay()
    {
        yield return _wait;

        Deactivate();
    }

    private void Deactivate()
    {
        if (_deactivateCoroutine != null)
        {
            StopCoroutine(_deactivateCoroutine);
        }

        OnDeactivated();
    }
}
