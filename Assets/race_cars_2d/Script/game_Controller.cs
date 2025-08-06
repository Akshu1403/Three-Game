 using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class game_Controller : MonoBehaviour
{
    public Text highscoreText;
    public int highscore;

    public Text scoreText;
    public int score;

    public GameObject pausePanel;
    public GameObject pausebtn;
    void Start()
    {
        pausePanel.SetActive(false);
        pausebtn .SetActive(true);
    }
    void Update()
    {
        score_Manager.Instance.highScore =PlayerPrefs .GetInt("high_Score");
        score = score_Manager.Instance.score;
        highscoreText.text = "HighScore: " + score_Manager.Instance.highScore.ToString();
        scoreText.text = "Your Score: " + score_Manager.Instance.score.ToString();
    }
    public void restastBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void pauseBtn()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        pausebtn .SetActive(false);
    }
    public void resumeBtn()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        pausebtn .SetActive(true);
    }
}
