using UnityEngine;

public class BulletMover
{
    private Transform _bullet;
    private float _speed;

    public BulletMover(Transform bullet, float speed)
    {
        _bullet = bullet;
        _speed = speed;
    }

    public void Move()
    {
        Vector2 step = _bullet.right * _speed * Time.deltaTime;
        _bullet.position = (Vector2)_bullet.position + step;
    }
}
