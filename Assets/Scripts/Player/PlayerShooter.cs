using System;
using System.Collections;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _reloadTime = 0.5f;

    private BulletShooter _bulletShooter;
    private WaitForSeconds _wait;
    private bool _isReloading;

    public void Initialize(Func<Bullet> getBulletFunc)
    {
        _bulletShooter = new BulletShooter(BulletOwner.Player, _shootPoint, getBulletFunc);
        _wait = new WaitForSeconds(_reloadTime);
    }

    public void TryShoot()
    {
        if (_isReloading == false)
        {
            _bulletShooter.Shoot();
            StartCoroutine(Reloading());
        }
    }

    private IEnumerator Reloading()
    {
        _isReloading = true;

        yield return _wait;

        _isReloading = false;
    }
}
