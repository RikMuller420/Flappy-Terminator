using System;
using UnityEngine;

public class BulletShooter
{
    private Func<Bullet> _getBulletFunc;
    private BulletOwner _owner;
    private Transform _shootPoint;

    public BulletShooter(BulletOwner owner, Transform shootPoint, Func<Bullet> getBulletFunc)
    {
        _owner = owner;
        _shootPoint = shootPoint;
        _getBulletFunc = getBulletFunc;
    }

    public void Shoot()
    {
        Bullet bullet = _getBulletFunc();
        bullet.transform.position = _shootPoint.position;
        bullet.transform.rotation = _shootPoint.rotation;
        bullet.Initialize(_owner);
    }
}
