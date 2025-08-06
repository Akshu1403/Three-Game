using UnityEngine;

public class background : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private Renderer rend;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        Gamemaneger .Instance.isgmOver = false ;
    }

    void Update()
    {
        if (!Gamemaneger.Instance.isgmOver)
        {
            offset.x += scrollSpeed * Time.deltaTime;
            rend.material.mainTextureOffset = offset;

        }
       
    }
}
