using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 4.5f;
    public GameObject player;
    Vector3 direction;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        direction = ChangeDirection();

    }

    private void Update() {
       transform.position += direction * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")){
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        else if (collision.gameObject.CompareTag("Player")){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private Vector3 ChangeDirection()
    {
        if (player.transform.position.x >= transform.position.x){
            direction = transform.right;
            Debug.Log("here");
        }
        else
        {
            direction = -transform.right;
            Debug.Log("here2");
        }
        return direction;
    }
}