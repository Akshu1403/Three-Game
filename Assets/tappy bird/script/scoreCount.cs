using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class scoreCount : MonoBehaviour
{
    public static scoreCount Instance { get; private set; }
    public Text scoreText;
    public  int score = 0;
    public Text gameOverScore;

    private void Awake()
    {
        Instance = this;    
    }
    private void Update()
    {
        scoreText.text = score.ToString();
        gameOverScore .text ="score "+ score.ToString();
    }
    public void addScore()
    {
        score++;
    }
}
