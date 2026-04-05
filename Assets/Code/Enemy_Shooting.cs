using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject Bullet;
    public Transform firePoint;
    private float time = 0f;
    public float interpolationPeriod = 0.1f;

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Mouse0))
        // {
        //     Instantiate(Bullet, firePoint.position, transform.rotation);
        // }

        time += Time.deltaTime;

        if (time >= interpolationPeriod) {
            time = 0;
            Instantiate(Bullet, firePoint.position, transform.rotation);
        }

    }

   
}