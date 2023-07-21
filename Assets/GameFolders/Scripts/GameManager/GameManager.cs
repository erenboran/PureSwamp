using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : SingletonMonoBeheviorObject<GameManager>
{
    private int score;
    public Text ScoreText;


    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    private void OnEnable()
    {
        GameEvents.Instance.OnScoreChanged += IncreaseScore;
    }

    private void OnDisable()
    {
        GameEvents.Instance.OnScoreChanged -= IncreaseScore;
    }


    void Awake()
    {
        SingletonThisObject(this);
    }
    void Start()
    {
        score = 0;

    }
    void Update()
    {
        ScoreText.text = score.ToString();
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }


    public void IncreaseScore(int amount)
    {
        score += amount;
    }
}
