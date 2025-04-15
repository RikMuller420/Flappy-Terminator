public class EnemyHitHandler : IBulletHitHandler
{
    public void Hit(Bullet bullet, IInteractable interactable)
    {
        if (bullet.Owner == BulletOwner.Player && interactable is Enemy enemy)
        {
            enemy.Destroy();
            bullet.Deactivate();
        }
    }
}
