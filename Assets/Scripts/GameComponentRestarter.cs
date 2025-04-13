using System;

public class GameComponentRestarter
{
    private Action _restartAction;

    public GameComponentRestarter(EnemyGenerator enemyGenerator, EnemyPool enemyPool,
                                    BulletPool bulletPool, ScoreCounter scoreCounter,
                                    Player player)
    {
        _restartAction = () =>
        {
            player.Restart();
            scoreCounter.Restart();
            enemyGenerator.Restart();
            enemyPool.ReleaseActiveObjects();
            bulletPool.ReleaseActiveObjects();
        };
    }

    public void Restart()
    {
        _restartAction.Invoke();
    }
}
