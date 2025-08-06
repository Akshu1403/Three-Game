using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingSM : MonoBehaviour
{
    public GameObject settingPanel;
    public Slider Sound;
    public Slider music;

    private void OnEnable()
    {
        settingPanel.transform.localScale = Vector3.zero;
        settingPanel.transform.DOScale(Vector3.one, 0.8f);
    }
    void Start()
    {
        Sound.onValueChanged.AddListener((N) =>
        {
            musicManage.Instance.changeSound(N);
        });
        music.onValueChanged.AddListener((N) =>
        {
            musicManage.Instance.changeMusic(N);
        });
    }
    public void exitpanel()
    {
        settingPanel.transform.DOScale(Vector3.zero, 0.8f).OnComplete(() =>
        {
            settingPanel.SetActive(false);
        });
    }
}
