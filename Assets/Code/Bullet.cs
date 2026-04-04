using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Lifetime")]
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}