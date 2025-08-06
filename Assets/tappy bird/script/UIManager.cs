using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject pausePanelButton;

    private void Update()
    {
        pausePanelButton.SetActive(!Gamemaneger.Instance.isgmOver);
    }


    public void startBtn()
    {
        SceneManager.LoadScene(2);
    }
    public void exitBtn()
    {
        Application.Quit();
    }
    public void pauseBtn()
    {
        Gamemaneger.Instance.isgmOver = true;
        rb.bodyType = RigidbodyType2D.Static; 
    }

    public void resumeBtn()
    {
        Gamemaneger.Instance.isgmOver = false;
        rb.bodyType= RigidbodyType2D.Dynamic;
    }
    public void menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void retryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void pausePanel()
    {
        Gamemaneger.Instance.PausePanel();
    }

}
