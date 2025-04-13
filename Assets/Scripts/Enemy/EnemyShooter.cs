using System;
using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _reloadTime = 0.5f;

    private BulletShooter _bulletShooter;
    private WaitForSeconds _wait;
    private Coroutine _shootCoroutine;

    public void Initialize(Func<Bullet> getBulletFunc)
    {
        _wait = new WaitForSeconds(_reloadTime);
        _bulletShooter = new BulletShooter(BulletOwner.Enemy, _shootPoint, getBulletFunc);
    }

    public void StartShooting()
    {
        _shootCoroutine = StartCoroutine(ShootRepeatedly());
    }

    public void StopShooting()
    {
        if (_shootCoroutine != null)
        {
            StopCoroutine(_shootCoroutine);
        }
    }

    private IEnumerator ShootRepeatedly()
    {
        while (enabled)
        {
            _bulletShooter.Shoot();

            yield return _wait;
        }
    }
}
