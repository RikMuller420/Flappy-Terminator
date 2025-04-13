using UnityEngine;

public class BackgoundMover : MonoBehaviour
{
    [SerializeField] private Transform _background;
    [SerializeField] private Transform _player;

    private void LateUpdate()
    {
        Vector2 position = _background.position;
        position.x = _player.position.x;
        _background.position = position;
    }
}
