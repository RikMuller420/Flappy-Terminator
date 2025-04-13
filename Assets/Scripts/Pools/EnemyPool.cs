using System;

public class EnemyPool : GenericPool<Enemy>
{
    private Action<Enemy> _initializeEnemyDelegate;
    private Action<Enemy> _deinitializeEnemyDelegate;

    public void Initialize(Action<Enemy> initializeEnemyDelegate, Action<Enemy> deinitializeEnemyDelegate)
    {
        _initializeEnemyDelegate = initializeEnemyDelegate;
        _deinitializeEnemyDelegate = deinitializeEnemyDelegate;
    }

    protected override void InitializeObject(PoolableObject instance)
    {
        _initializeEnemyDelegate?.Invoke(instance as Enemy);
    }

    protected override void DeinitializeObject(PoolableObject instance)
    {
        _deinitializeEnemyDelegate?.Invoke(instance as Enemy);
    }
}
