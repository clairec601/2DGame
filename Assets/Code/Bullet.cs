using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float Speed = 4.5f;

    private void Update() {
        transform.position += transform.right * Time.deltaTime * Speed;

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
}