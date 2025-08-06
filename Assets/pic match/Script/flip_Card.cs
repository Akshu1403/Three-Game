using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class flip_Card : MonoBehaviour
{
    public static flip_Card Instance { get; private set; }
    public Button button;
    public Sprite newSprite;
    public Sprite bgSprite;
    public bool isflip = false;

    private void Awake()
    {
        Instance = this;
    }
    public void FlipOpen()
    {

        transform.DORotate(new Vector3(0, 90, 0), 0.25f).OnComplete(() =>
        {
            button.image.sprite = newSprite;
            isflip = true;

            transform.DORotate(new Vector3(0, 180, 0), 0.25f);
        });
    }

    public void FlipBack()
    {

        transform.DORotate(new Vector3(0, 90, 0), 0.25f).OnComplete(() =>
        {
            button.image.sprite = bgSprite;
            isflip = false;

            transform.DORotate(new Vector3(0, 0, 0), 0.25f);
        });
    }
}

