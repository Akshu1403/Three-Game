using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }
    public GameObject gamePLay;
    public GameObject levelPanel;
    public GameObject lvlCompletPanel;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    private void Start()
    {
        gamePLay.SetActive(false);
        levelPanel.SetActive(true);
        lvlCompletPanel.SetActive(false);  
    }
    public void onGame()
    {
        gamePLay.SetActive(true);
        gamePLay.transform.DOScale(Vector3.one, 0.8f);
        levelPanel.SetActive(false);
        levelPanel.transform.DOScale(Vector3.zero, 0.8f);
    }
    public void menuBtn()
    {
        SceneManager.LoadScene(0);
    }
    public void exitBtn()
    {
        Application.Quit();
    }
}
