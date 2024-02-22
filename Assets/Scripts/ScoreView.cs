using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private KillScore _scoreCounter;
    [SerializeField] private TMP_Text _score;

    private void Start()
    {
        _score.text = "";
    }

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = "Убито: " + score.ToString();
    }
}