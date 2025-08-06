using DG.Tweening;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Transform transform;
    float speed = 3f;
    float rotationSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverPanel.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        clamp();
    }

    //move player in left and right
    void movement()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 140), rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -140), rotationSpeed * Time.deltaTime);
        }
        if (transform.rotation.z != 180)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 180), 10f * Time.deltaTime);
        }

    }

    //player clamp in screen size
    void clamp()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -2f, 2f);
        transform.position = pos;
    }

    // destroy player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "car")
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            //gameOverPanel.transform.localScale = Vector3.zero;
            //gameOverPanel.transform.DOScale(Vector3.one, 0.8f);
        }

        if (collision.gameObject.tag == "Coin")
        {
            score_Manager.Instance.score += 10;
            Destroy(collision.gameObject);
        }
    }
}
