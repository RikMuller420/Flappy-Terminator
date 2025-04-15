public class PlayerHitHandler : IBulletHitHandler
{
    public void Hit(Bullet bullet, IInteractable interactable)
    {
        if (bullet.Owner == BulletOwner.Enemy && interactable is Player player)
        {
            player.Destroy();
            bullet.Deactivate();
        }
    }
}
