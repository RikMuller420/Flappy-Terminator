using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += UpdateScore;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= UpdateScore;
    }

    private void UpdateScore(int score)
    {
        _text.text = score.ToString();
    }
}
