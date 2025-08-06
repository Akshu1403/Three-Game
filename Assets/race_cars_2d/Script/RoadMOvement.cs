using UnityEngine;

public class RoadMOvement : MonoBehaviour
{
    public Renderer meshRender;
    public float speed = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meshRender.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
