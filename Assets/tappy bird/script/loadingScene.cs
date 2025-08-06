using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingScene : MonoBehaviour
{
    public Slider slider;
    public float speed = 5f;
    private float fill = 1f;
    private bool sceneLoaded=false;

    private void Start()
    {
        slider .value = 0f;
    }
    private void Update()
    {
        if (slider.value < fill)
        {
            slider.value += speed * Time.deltaTime;

        }
        else if (!sceneLoaded)
        {
            sceneLoaded = true;
            nextScene();
            
        }
    }
    void nextScene()
    {
        SceneManager.LoadScene(1);
    }
}
