using UnityEngine;

public class obstacl : MonoBehaviour
{
    public float speed = 3f;
    void Update()
    {
        if(!Gamemaneger.Instance.isgmOver)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}
