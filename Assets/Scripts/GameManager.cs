using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _live = 3;
    private int _score;

    private void Start()
    {
        ShowLiveAndScore();
    }

    public void ReduceLive()
    {
        if (_live == 0) return;
        _live -= 1;
        if (_live == 0)
        {
            Debug.Log($"Game Over, Score = {_score}");
            return;
        }
        ShowLiveAndScore();
    }

    public void IncreaseScore()
    {
        if (_live == 0) return;
        _score += 1;
        ShowLiveAndScore();
    }

    private void ShowLiveAndScore()
    {
        Debug.Log($"Lives = {_live}, Score = {_score}");
    }
}