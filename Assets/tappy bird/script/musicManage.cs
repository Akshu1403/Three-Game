using UnityEngine;

public class musicManage : MonoBehaviour
{
    public static musicManage Instance { get; private set; }
    public AudioSource sound;
    public AudioSource music;

    public AudioClip overEffect;
    public AudioClip tapEffect;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void changeSound(float soundValue)
    {
        sound.volume = soundValue;
    }
    public void changeMusic(float musicValue)
    {
        music.volume = musicValue;
    }
    public void playClip(AudioClip ac)
    {
        sound.PlayOneShot (ac);
    }
}
