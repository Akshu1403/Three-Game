using DG.Tweening;
using UnityEngine;

public class Gamemaneger : MonoBehaviour
{
    public static Gamemaneger Instance {  get; private set; }

    public GameObject gameOver;
    public GameObject pausePanel;
    public GameObject obstacl;
    public float timer = 0f;
    public float speed = 2f;
    public bool isgmOver = false;
    public float X = -6f;

    private void Awake()
    {
        Instance = this;
        
    }
    private void Start()
    {
        gameOver.SetActive(false);
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (timer <= 0f)
        {
            if (!isgmOver)
            {
                GameObject gm = Instantiate(obstacl, new Vector3(5f, Random.Range(1.5f, -2f), 0f), Quaternion.identity);
                timer = 4f;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
        
    }
    public void PausePanel()
    {
        pausePanel.SetActive(true);
        pausePanel.transform.localScale = Vector3.zero;
        pausePanel.transform.DOScale(Vector3.one, 0.8f);
    }
}

