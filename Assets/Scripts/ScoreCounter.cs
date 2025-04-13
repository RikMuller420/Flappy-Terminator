using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> ScoreChanged;

    public void Restart()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }

    public void Add()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
}
