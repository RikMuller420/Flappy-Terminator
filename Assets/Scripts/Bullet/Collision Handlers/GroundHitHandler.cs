public class GroundHitHandler : IBulletHitHandler
{
    public void Hit(Bullet bullet, IInteractable interactable)
    {
        bullet.Deactivate();
    }
}
