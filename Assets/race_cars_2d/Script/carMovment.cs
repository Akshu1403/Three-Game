using UnityEngine;

public class carMovment : MonoBehaviour
{
    public Transform transform;
    public float speed = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        moveCar();
    }
    // to give movement to the car
    void moveCar()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }

}
