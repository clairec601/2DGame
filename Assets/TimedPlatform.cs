using UnityEngine;
using System.Collections;


public class TimedPlatform : MonoBehaviour
{

    public float timeBeforeFall = 5.0f;
    public GameObject player;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){ //fix this
            StartCoroutine(PlatformFall());
        }
        if (collision.gameObject.CompareTag("Ground")){
            Destroy(gameObject);
        }
        
    }

    IEnumerator PlatformFall()
    {
        yield return new WaitForSeconds(timeBeforeFall);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
