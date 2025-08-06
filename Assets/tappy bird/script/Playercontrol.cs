using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Playercontrol : MonoBehaviour
{
    public static Playercontrol Instance {  get; private set; }
    private Rigidbody2D  rb;
    public float force= 5f;
    public GameObject  explotionEffect;
    public bool Score=false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * force;
            musicManage.Instance.playClip(musicManage.Instance.tapEffect);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Obstacl"))
        {
            Gamemaneger.Instance.isgmOver = true;
            rb.bodyType = RigidbodyType2D.Static;
            Instantiate(explotionEffect, transform.position, Quaternion.identity);
            StartCoroutine(over());



        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!Score && other .CompareTag("Score"))
        {
            scoreCount.Instance.addScore();
        }
    }
    public IEnumerator over()
    {
        yield return new WaitForSeconds(1f);
        Gamemaneger.Instance.gameOver.SetActive(true);
        Gamemaneger.Instance.gameOver.transform.localScale = Vector3.zero;
        Gamemaneger.Instance.gameOver.transform.DOScale(Vector3.one,0.8f);
        musicManage.Instance.playClip(musicManage.Instance.overEffect);
        Destroy (gameObject );
    }
    
}
