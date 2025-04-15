public class GroundHitHandler : IBulletHitHandler
{
    public void Hit(IInteractable interactable, Bullet bullet)
    {
        bullet.Deactivate();
    }
}
