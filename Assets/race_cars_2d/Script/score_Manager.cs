using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class score_Manager : MonoBehaviour
{
    public static score_Manager Instance {  get; private set; }
    public int score = 0;
    public int highScore;
    public static int lastScore = 0;

    public Text scoreText;
    public Text highScoreText;
    public Text lastScoreText;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(Score());

        highScore = PlayerPrefs.GetInt("high_Score",0);
        highScoreText.text = "HighScore: " + highScore.ToString();
        lastScoreText.text = "LastScore: " + lastScore.ToString();
    }

    void Update()
    {
        scoreText.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("high_Score", highScore);
        }
    }
    
    // to do the score count
    IEnumerator Score()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            score = score + 1;
            lastScore = score; 
        }
    }
}
