using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private Player _player;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private ScoreCounter _scoreCounter;

    private GameComponentRestarter _restarter;

    public void Awake()
    {
        _restarter = new GameComponentRestarter(_enemyGenerator, _enemyPool, _bulletPool,
                                                _scoreCounter, _player);

        _player.Initialize(_bulletPool.Get);
        _enemyPool.Initialize(InitializeEnemy, DeinitializeEnemy);
        _game.Initialize(_player, _mainMenu, _restarter);
    }

    private void InitializeEnemy(Enemy enemy)
    {
        enemy.Initialize(_bulletPool.Get, _player.transform);
        enemy.Destroyed += _scoreCounter.Add;
    }

    private void DeinitializeEnemy(Enemy enemy)
    {
        enemy.Destroyed -= _scoreCounter.Add;
    }
}
