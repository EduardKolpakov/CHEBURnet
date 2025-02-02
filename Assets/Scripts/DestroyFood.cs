using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DestroyFood : MonoBehaviour
{
    public float orangeSpeed = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("basket"))
        {
            ScoreManager.AddScore(1);
            Destroy(gameObject);
        }
        else if (other.CompareTag("floor"))
        {
            LivesScript.singlton.LoseLife();
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        orangeSpeed = newSpeed;
    }
}