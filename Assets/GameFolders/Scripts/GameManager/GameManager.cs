using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score;
    public Text ScoreText;

    [SerializeField]
    TMP_Text gameOverScoreText;

    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    Button restartButton;
    [SerializeField]
    Button mainMenuButton;

    [SerializeField]
    string mainSceneName;


    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    private void OnEnable()
    {
        GameEvents.Instance.OnScoreChanged += IncreaseScore;
        GameEvents.Instance.OnGameEnded += GameEnd;
    }

    private void OnDisable()
    {
        GameEvents.Instance.OnScoreChanged -= IncreaseScore;
        GameEvents.Instance.OnGameEnded -= GameEnd;
    }


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);

        }
    }

    private void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(RestartGame);
    }


    void GameEnd()
    {
        StopGame();
        gameOverScoreText.text = score.ToString();
        gameOverPanel.SetActive(true);

    }

    public void ResumeGame()
    {

        Time.timeScale = 1;

    }
    public void StopGame()
    {
        Time.timeScale = 0;
    }


    public void IncreaseScore(int amount)
    {
        score += amount;
        ScoreText.text = score.ToString();
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainSceneName);

    }
}
