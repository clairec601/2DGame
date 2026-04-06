using UnityEngine;

public class Bullet_Type2 : MonoBehaviour
{
    public float Speed = 4.5f;
    void Update()
    {
        transform.position -= transform.right * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
