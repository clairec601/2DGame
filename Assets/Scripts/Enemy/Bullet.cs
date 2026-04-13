using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 4.5f;

    private void Update() {
        transform.position += transform.right * Time.deltaTime * Speed;

    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);

        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}