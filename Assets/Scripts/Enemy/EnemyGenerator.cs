using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private float secondsPerEnemy = 5f;
    [SerializeField] private float minPositionX = 14f;
    [SerializeField] private float maxPositionX = 18f;
    [SerializeField] private float minPositionY = -5f;
    [SerializeField] private float maxPositionY = 5f;

    private WaitForSeconds _wait;
    private Coroutine _createCorutine;

    public void Awake()
    {
        _wait = new WaitForSeconds(secondsPerEnemy);
        RestartCreatingCorutine();
    }

    public void Restart()
    {
        RestartCreatingCorutine();
    }

    private void RestartCreatingCorutine()
    {
        if (_createCorutine != null)
        {
            StopCoroutine(_createCorutine);
        }

        _createCorutine = StartCoroutine(CreateRepeatedly());
    }

    private IEnumerator CreateRepeatedly()
    {
        while (enabled)
        {
            yield return _wait;

            Enemy enemy = _enemyPool.Get();
            float positionX = Random.Range(minPositionX, maxPositionX);
            float positionY = Random.Range(minPositionY, maxPositionY);
            enemy.Appear(positionX, positionY);
            enemy.gameObject.SetActive(true);
        }
    }
}
