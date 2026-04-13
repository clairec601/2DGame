using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject Bullet;
    public Transform firePoint;
    private float time = 0f;
    public float cooldown = 1f;

    private AudioSource src;

    [SerializeField] private AudioClip SFX;

    private void Start()
    {

        src = GetComponent<AudioSource>();

    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Mouse0))
        // {
        //     Instantiate(Bullet, firePoint.position, transform.rotation);
        // }

        time += Time.deltaTime;

        if (time >= cooldown) {
            time = 0;

            src.PlayOneShot(SFX);

            Instantiate(Bullet, firePoint.position, firePoint.rotation);
        }

    }

   
}